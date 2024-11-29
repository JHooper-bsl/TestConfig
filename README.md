The purpose of this project is to test how dotnet binds string arrays from appsettings config.

Currently I've just got a single controller which I have injected in my config. This controller method will return the config. 

I've additionally gone and added in some asserts to the data which for some unexpected reason the application is duplicating the values within the config array. Therefore this is throwing.
