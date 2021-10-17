# Vice City - Custom Mission Loader
### Info
Simple tool to make the game load the main.scm file from another directory.
### How it works
Starts gta-vc.exe
Attaches itself to the process with full access
Inserts a new string into an unused memory address
Redirects the original string address to the modified
Closes itself
When the game loads it will use the modified path to load main.scm
