@echo off

set reportFolderLocation=.

echo * Runing unit test cover *
cd %reportFolderLocation%
call OpenCoverAPI.bat %dllLocation% %reportFolderLocation%\reports * *

pause