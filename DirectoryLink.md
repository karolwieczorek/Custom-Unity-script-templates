As it's repository and it would be nice to have it in one place with other repositories where it could be easly edited. 
But also it was inside unity resources directory and worked as templates directory. 
To have both behavours we can create directory link from repository directory to path inside unity resources.
To do that we need to execute command from terminal with admin rights:

**Windows**  
hard link: mklink /J Link Target (tested)  
soft link: mklink /D Link Target  
  
**OS X**  
soft link: ln -s target link  
  
If you're not familiar with hard- and sym- links it's better to just copy files to proper directory insead of mess with file system, since you do it at your own risk.