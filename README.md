# RimWorld_RemoteDebug

https://wiki.python.org/moin/WindowsCompilers

https://www.microsoft.com/en-us/download/details.aspx?id=23510

set subinacl="C:\Program Files (x86)\Windows Resource Kits\Tools\subinacl.exe"
pause

for /f "tokens=2*" %%a in ('reg query "HKLM\Software\Microsoft\NET Framework Setup\NDP\v4\Client" /v Version /reg:32') do set "CurrentNDPv4ClientVersion=%%~b"
pause
for /f "tokens=2*" %%a in ('reg query "HKLM\Software\Microsoft\NET Framework Setup\NDP\v4\Full" /v Version /reg:32') do set "CurrentNDPv4FullVersion=%%~b"
pause

%subinacl% /subkeyreg "HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\NET Framework Setup\NDP\v4" /setowner="%username%"
pause
%subinacl% /subkeyreg "HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\NET Framework Setup\NDP\v4" /grant="%username%"=f
pause
reg ADD "HKLM\Software\Microsoft\NET Framework Setup\NDP\v4\Full" /v Version /t REG_SZ /d 4.0.30319 /reg:32 /f
reg ADD "HKLM\Software\Microsoft\NET Framework Setup\NDP\v4\Client" /v Version /t REG_SZ /d 4.0.30319 /reg:32 /f

echo start your installer now
pause

reg ADD "HKLM\Software\Microsoft\NET Framework Setup\NDP\v4\Client" /v Version /t REG_SZ /d %CurrentNDPv4ClientVersion% /reg:32 /f
reg ADD "HKLM\Software\Microsoft\NET Framework Setup\NDP\v4\Full" /v Version /t REG_SZ /d %CurrentNDPv4FullVersion% /reg:32 /f

%subinacl% /subkeyreg "HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\NET Framework Setup\NDP\v4" /revoke="%username%"
%subinacl% /subkeyreg "HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\NET Framework Setup\NDP\v4" /setowner="NT SERVICE\TrustedInstaller"