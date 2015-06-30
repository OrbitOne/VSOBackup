# VSOBackup
This is our Visual Studio Online backup tool. You can find more info on our [blog](http://blog.orbitone.com/post/Visual-Studio-Online-Backup-Tool)

We use the VSO Rest API  to query our VSO account and get all the data we need. Since in VSO you can only have one Team Project Collection, we retrieve all the team projects of the default collection. Each of these team projects can have multiple repositories that need to be backed up. A folder is created for each team project and saved to a location on disk that can be configured in the app.config. When the team project folder is created, the task loops over each repository in the team project and creates folders for each repository.

![alt tag](http://blogs.msdn.com/cfs-filesystemfile.ashx/__key/communityserver-blogs-components-weblogfiles/00-00-00-54-43-metablogapi/1106.image_5F00_65A15B92.png)


The actual backing up of the repositories is done by using a clone url that we can get from the VSO REST Api.This URL looks just like the one you'd see on github, for example: https://orbitone.visualstudio.com/DefaultCollection/OrbitOne/_git/CrmDataAccess.
To clone the repositories we use the libGit2Sharp library. Including this in your project is easy, you can use NuGet to download and install it.This library makes cloning of repositories very easy. All you have to do is call Repository.Clone() and pass in the clone URL and the destination.

Important to note is that you need to have Alternative Credentials enabled in your VSO account. You need this to access the VSO Rest API and to clone repositories using the libGit2Sharp library. You can set these credentials by going to your profile in your VSO account.

On top of that, we also added a configurable key called "RemoveBackupAfterHowManyDays". With this key, we can decide for how long we want to retain the oldest backup. Right now we have this set 10 days, meaning that we will store a complete repository backup for only 10 days. After that, the backup will be deleted from disk.

As mentioned before, we also made the path/location where to save these backups configurable. The REST Urls needed to query our VSO accounts are also configurable. For example, this is one of the URLs we use to get all our repositories.

https://orbitone.visualstudio.com/DefaultCollection/_apis/git/repositories?api-version=1.0

Having this hardcoded would not be that convenient, since

    The api function's name might change
    We might change our vso account, or use a different name

By having this in the app.config, you can basically use this task as a backuptool for different VSO accounts. Just schedule another instance of the task with different settings, and you're good to go.
By having these app settings, it enables you to quickly change some settings, without having to recompile or redeploy the application.

 
