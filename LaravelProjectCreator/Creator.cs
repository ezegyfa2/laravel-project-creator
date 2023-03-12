using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LaravelProjectCreator
{
    public enum AdminType { Nothing, BlueAdmin }

    public class Creator
    {
        public string ProjectName;
        public bool HasPackages
        {
            get
            {
                return NodeModulesFolderPath != null && NodeModulesFolderPath != "" && LaravelModulesFolderPath != null && LaravelModulesFolderPath != "";
            }
        }

        #region filePaths

        public string ProjectsFolderPath;
        public string NodeModulesFolderPath;
        public string LaravelModulesFolderPath;
        public DatabaseConnection DatabaseConnection;
        public string EnvFilePath
        {
            get
            {
                return Path.Combine(ProjectFolderPath, ".env");
            }
        }

        public string AppConfigFilePath
        {
            get
            {
                return Path.Combine(ConfigFolderPath, "app.php");
            }
        }

        public string DatabaseConfigFilePath
        {
            get
            {
                return Path.Combine(ConfigFolderPath, "database.php");
            }
        }

        public string ConfigFolderPath
        {
            get
            {
                return Path.Combine(ProjectFolderPath, "config");
            }
        }

        public string TemplateFolderPath
        {
            get
            {
                return Path.Combine(AppFolderPath, "Templates");
            }
        }

        public string AppServiceProviderFilePath
        {
            get
            {
                return Path.Combine(AppFolderPath, "Providers", "AppServiceProvider.php");
            }
        }

        public string MiddlewareFolderPath
        {
            get
            {
                return Path.Combine(HttpFolderPath, "Middleware");
            }
        }

        public string HttpFolderPath
        {
            get
            {
                return Path.Combine(AppFolderPath, "Http");
            }
        }

        public string AppFolderPath
        {
            get
            {
                return Path.Combine(ProjectFolderPath, "app");
            }
        }

        public string AppScssFilePath
        {
            get
            {
                return Path.Combine(ResourceFolderPath, "sass", "app.scss");
            }
        }

        public string ScssFolderPath
        {
            get
            {
                return Path.Combine(ResourceFolderPath, "sass");
            }
        }

        public string AppJsFilePath
        {
            get
            {
                return Path.Combine(JsResourceFolderPath, "app.js");
            }
        }

        public string BootstrapJsFilePath
        {
            get
            {
                return Path.Combine(JsResourceFolderPath, "bootstrap.js");
            }
        }

        public string JsResourceFolderPath
        {
            get
            {
                return Path.Combine(ResourceFolderPath, "js");
            }
        }

        public string WebpackJsFilePath
        {
            get
            {
                return Path.Combine(ProjectFolderPath, "webpack.mix.js");
            }
        }

        public string ViewsFolderPath
        {
            get
            {
                return Path.Combine(ResourceFolderPath, "views");
            }
        }

        public string WebRouteFilePath
        {
            get
            {
                return Path.Combine(ProjectFolderPath, "routes", "web.php");
            }
        }

        public string ResourceFolderPath
        {
            get
            {
                return Path.Combine(ProjectFolderPath, "resources");
            }
        }

        public string ProjectFolderPath
        {
            get
            {
                return Path.Combine(ProjectsFolderPath, ProjectName);
            }
        }

        #endregion

        public Creator(string projectName, string projectsFolderPath, DatabaseConnection databaseConnection, string nodeModulesFolderPath = null, string laravelModulesFolderPath = null)
        {
            this.ProjectName = projectName;
            this.ProjectsFolderPath = projectsFolderPath;
            this.NodeModulesFolderPath = nodeModulesFolderPath;
            this.LaravelModulesFolderPath = laravelModulesFolderPath;
            DatabaseConnection = databaseConnection;
        }

        public void Create(AdminType adminType)
        {
            createLaravelProject();
            installPackages();
            updateEnvFile();
            updateConfigFiles();
            addGdprMiddlewares();
            addDesignTemplate();
            updateServiceProvider();
            addDesignerRoutes();
            addFontAwesome();
            updateAppScss();
            updateAppJs();
            updateBootstrapJs();
            updateWebpackJs();
            if (HasPackages)
            {
                executeProcess("php", "artisan cnm --nonpm");
            }
            addAdmin(adminType);
            addViews();
            if (HasPackages)
            {
                executeProcess("php", "artisan cnm --nonpm");
            }
            executeProcess("npm", "run dev");
            executeProcess("php", "artisan route:cache");
        }

        protected void createLaravelProject()
        {
            if (ProjectCreated)
            {
                throw new Exception("Project was already created");
            }
            else
            {

                executeProcess("composer", "create-project --prefer-dist laravel/laravel " + ProjectName + " \"8.*\"", ProjectsFolderPath);
            }
        }
        
        public bool ProjectCreated
        {
            get 
            {
                var directory = new DirectoryInfo(ProjectsFolderPath);
                var laravelProjectNames = directory.GetDirectories().Select(subDirectory => subDirectory.Name);
                return laravelProjectNames.Contains(ProjectName);
            }
        }

        #region updateFiles

        protected void updateEnvFile()
        {
            string envFileContent = File.ReadAllText(EnvFilePath);
            envFileContent = envFileContent.Replace("APP_NAME=Laravel", "APP_NAME=" + ProjectName);
            envFileContent = envFileContent.Replace("DB_HOST=127.0.0.1", "DB_HOST=" + DatabaseConnection.Host);
            envFileContent = envFileContent.Replace("DB_PORT=3306", "DB_PORT=" + DatabaseConnection.Port);
            envFileContent = envFileContent.Replace("DB_DATABASE=laravel", "DB_DATABASE=" + DatabaseConnection.DatabaseName);
            envFileContent = envFileContent.Replace("DB_USERNAME=root", "DB_USERNAME=" + DatabaseConnection.UserName);
            envFileContent = envFileContent.Replace("DB_PASSWORD=", "DB_PASSWORD=" + DatabaseConnection.Password);
            File.WriteAllText(EnvFilePath, envFileContent);
        }

        protected void updateConfigFiles()
        {
            if (HasPackages)
            {
                updateAppConfigFile();
            }
            updateDatabaseConfigFile();
        }

        protected void updateAppConfigFile()
        {
            string configFileContent = File.ReadAllText(AppConfigFilePath);
            configFileContent = configFileContent.Replace("return [", "return [\r\n\r\n    'node_modules_folder_path' => '" + NodeModulesFolderPath + "',"
                + "\r\n\r\n    'laravel_methods_folder_path' => '" + LaravelModulesFolderPath + "',");
            File.WriteAllText(AppConfigFilePath, configFileContent);
        }

        protected void updateDatabaseConfigFile()
        {
            string configFileContent = File.ReadAllText(DatabaseConfigFilePath);
            configFileContent = configFileContent.Replace("return [", "return [\r\n\r\n    'admin' => [],");
            File.WriteAllText(DatabaseConfigFilePath, configFileContent);
        }

        protected void addGdprMiddlewares()
        {
            createFileFromResource(
                Path.Combine(MiddlewareFolderPath, "AddQueuedCookiesToResponse.php"),
                "LaravelProjectCreator.Resources.AddQueuedCookiesToResponse.txt"
            );
            createFileFromResource(
                Path.Combine(MiddlewareFolderPath, "CookieConsent.php"), 
                "LaravelProjectCreator.Resources.CookieConsent.php"
            );
            createFileFromResource(
                Path.Combine(MiddlewareFolderPath, "ShareErrorsFromSession.php"),
                "LaravelProjectCreator.Resources.ShareErrorsFromSession.txt"
            );
            createFileFromResource(
                Path.Combine(MiddlewareFolderPath, "StartSession.php"),
                "LaravelProjectCreator.Resources.StartSession.txt"
            );
            updateEncryptCookies();
            updateVerifyCsrfToken();
            updateKernel();
        }

        protected void updateEncryptCookies() 
        {
            string encryptCookiesPath = Path.Combine(MiddlewareFolderPath, "EncryptCookies.php");
            string encryptCookiesContent = File.ReadAllText(encryptCookiesPath);
            encryptCookiesContent.Replace(
                "protected $except = [", 
                "protected $except = [\n'consent',"
            );
            File.WriteAllText(encryptCookiesPath, encryptCookiesContent);
        }

        protected void updateVerifyCsrfToken() 
        {
            string verifyCsrfTokenPath = Path.Combine(MiddlewareFolderPath, "VerifyCsrfToken.php");
            string verifyCsrfTokenContent = File.ReadAllText(verifyCsrfTokenPath);
            verifyCsrfTokenContent.Replace(
                "use Illuminate\\Foundation\\Http\\Middleware\\VerifyCsrfToken", 
                "use Closure;\nuse Illuminate\\Foundation\\Http\\Middleware\\VerifyCsrfToken"
            );
            File.WriteAllText(verifyCsrfTokenPath, verifyCsrfTokenContent);
        }

        protected void updateKernel()
        {
            string kernelPath = Path.Combine(HttpFolderPath, "Kernel.php");
            string kernelCsrfTokenContent = File.ReadAllText(kernelPath);
            kernelCsrfTokenContent.Replace(
                "\\Illuminate\\Cookie\\Middleware\\AddQueuedCookiesToResponse::class", 
                "\\App\\Http\\Middleware\\AddQueuedCookiesToResponse::class"
            );
            kernelCsrfTokenContent.Replace(
                "\\Illuminate\\Session\\Middleware\\StartSession::class", 
                "\\App\\Http\\Middleware\\StartSession::class"
            );
            kernelCsrfTokenContent.Replace(
                "\\Illuminate\\View\\Middleware\\ShareErrorsFromSession::class", 
                "\\App\\Http\\Middleware\\ShareErrorsFromSession::class"
            );
            File.WriteAllText(kernelPath, kernelCsrfTokenContent);
        }

        protected void addDesignTemplate()
        {
            Directory.CreateDirectory(TemplateFolderPath);
            createFileFromResource(Path.Combine(TemplateFolderPath, "designed.json"), "LaravelProjectCreator.Resources.Designed.txt");
        }

        protected void updateServiceProvider()
        {
            string appServiceProviderContent = getEmbeddedResourceContent("LaravelProjectCreator.Resources.AppServiceProvider.txt");
            File.WriteAllText(AppServiceProviderFilePath, appServiceProviderContent);
        }

        protected void addDesignerRoutes()
        {
            string webRouteContent = File.ReadAllText(WebRouteFilePath);
            webRouteContent = webRouteContent.Replace("<?php", "<?php\r\n\r\nuse Ezegyfa\\LaravelHelperMethods\\HttpMethods;");
            webRouteContent = webRouteContent + "\r\nHttpMethods::registerDesignerRoute();";
            File.WriteAllText(WebRouteFilePath, webRouteContent);
        }

        protected void addFontAwesome()
        {
            copyFolder("Resources/Fontawesome", Path.Combine(ResourceFolderPath, "fontawesome"));
        }

        protected void updateAppScss()
        {
            Directory.CreateDirectory(ScssFolderPath);
            string appScssFileContent = "@import '~bootstrap-select/sass/bootstrap-select.scss';\r\n"
                + "@import '~bootstrap/scss/bootstrap';\r\n"
                + "@import '../fontawesome/css/all.min.css';\r\n";
            createFile(AppScssFilePath, appScssFileContent);
        }

        protected void updateAppJs()
        {
            string appJsFileContent = File.ReadAllText(AppJsFilePath);
            appJsFileContent = appJsFileContent + "\r\nwindow.Vue = require('vue').default;"
                + "\r\n\r\nrequire('agency-landing-page-vue-components').default.install(Vue)"
                + "\r\n\r\nrequire('description-vue-components').default.install(Vue)"
                + "\r\n\r\nrequire('dynamic-web-vue-components').default.install(Vue)"
                + "\r\n\r\nrequire('grayscale-landing-page-vue-components').default.install(Vue)"
                + "\r\n\r\nrequire('gurulo-lofasz-vue-components').default.install(Vue)"
                + "\r\n\r\nrequire('helper-vue-components').default.install(Vue)"
                + "\r\n\r\nrequire('text-contents-vue-components').default.install(Vue)"
                + "\r\n\r\nrequire('web-page-designer-vue-components').default.install(Vue)"
                + "\r\n\r\nwindow.App = new Vue({\r\n    el: '#app',\r\n});\r\n";
            createFile(AppJsFilePath, appJsFileContent);
        }

        protected void updateBootstrapJs()
        {
            string bootstrapJsFileContent = File.ReadAllText(BootstrapJsFilePath);
            bootstrapJsFileContent = bootstrapJsFileContent
                + "\r\nwindow.Popper = require('popper.js').default;\r\n"
                + "window.$ = window.jQuery = require('jquery');\r\n\r\n"
                + "require('bootstrap');\r\n"
                + "require('bootstrap-select');\r\n"
                + "require('jquery.redirect')\r\n";
            File.WriteAllText(BootstrapJsFilePath, bootstrapJsFileContent);
        }

        protected void updateWebpackJs()
        {
            string webpackJsContent = getEmbeddedResourceContent("LaravelProjectCreator.Resources.WebpackJs.txt");
            File.WriteAllText(WebpackJsFilePath, webpackJsContent);
        }

        protected void addAdmin(AdminType adminType)
        {
            switch (adminType)
            {
                case AdminType.BlueAdmin:
                    addBlueAdmin();
                    break;
            }
        }

        protected void addBlueAdmin()
        {
            updateBlueAdminWebRoute();
            installBlueAdminPackage();
            updateBlueAdminAppJs();
        }

        protected void updateBlueAdminWebRoute()
        {
            string webRouteContent = File.ReadAllText(WebRouteFilePath);
            webRouteContent = webRouteContent.Replace("<?php", "<?php\r\n\r\nuse Ezegyfa\\LaravelHelperMethods\\Crm\\Controllers\\BlueAdminController;");
            webRouteContent = webRouteContent + "\r\n$blueAdminController = new BlueAdminController();\r\n$blueAdminController->initializeRoutes();";
            File.WriteAllText(WebRouteFilePath, webRouteContent);
        }

        protected void installBlueAdminPackage()
        {
            executeProcess("npm", "i blue-admin-vue-components");
        }

        protected void updateBlueAdminAppJs()
        {
            string appJsContent = File.ReadAllText(AppJsFilePath);
            appJsContent = appJsContent.Replace("window.Vue = require('vue').default", "window.Vue = require('vue').default\r\n\r\nrequire('blue-admin-vue-components').default.install(Vue)");
            File.WriteAllText(AppJsFilePath, appJsContent);
        }

        protected void addViews()
        {
            string layoutsPath = Path.Combine(ViewsFolderPath, "layouts");
            Directory.CreateDirectory(layoutsPath);
            createFileFromResource(Path.Combine(layoutsPath, "app.blade.php"), "LaravelProjectCreator.Resources.AppView.txt");
            createFileFromResource(Path.Combine(layoutsPath, "dynamicPage.blade.php"), "LaravelProjectCreator.Resources.DynamicView.txt");
        }

        protected void createFileFromResource(string filePath, string resourcePath)
        {
            string resourceContent = getEmbeddedResourceContent(resourcePath);
            createFile(filePath, resourceContent);
        }

        protected string getEmbeddedResourceContent(string resourcePath)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        protected void createFile(string filePath, string fileContent = "")
        {
            using (FileStream file = File.Create(filePath))
            using (StreamWriter writer = new StreamWriter(file))
            {
                writer.Write(fileContent);
            }
        }

        #endregion

        protected void installPackages()
        {
            executeProcess("npm", "i popper.js @popperjs/core jquery bootstrap@4.6.0 bootstrap-select axios vue@2.6.12 vue-loader@15.9.8 vue-template-compiler@2.6.12 pug "
                + "pug-plain-loader just-clone sass sass-loader node-sass path laravel-mix resolve-url-loader "
                + "js-helper-methods agency-landing-page-vue-components blue-admin-vue-components description-vue-components dynamic-web-vue-components "
                + "grayscale-landing-page-vue-components gurulo-lofasz-vue-components helper-vue-components text-contents-vue-components web-page-designer-vue-components");
            executeProcess("composer", "require ezegyfa/laravel-helper-methods");
        }

        protected void executeProcess(string exeName, string arguments, string folderPath = "")
        {
            ProcessStartInfo procInfo = new ProcessStartInfo(exeName);
            if (folderPath == "")
            {
                folderPath = ProjectFolderPath;
            }
            procInfo.WorkingDirectory = folderPath;
            procInfo.Arguments = arguments;
            Process.Start(procInfo).WaitForExit();
        }

        public static void copyFolder(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            copyAll(diSource, diTarget);
        }

        protected static void copyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                copyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

    }
}
