@Echo off
diskpart.exe < Y:\_Dido\_DiskpartMenu\MBR_Windows\TXT\MBR_XP.txt
bootsect /nt60 I: /force /mbr
Echo Now Ready to restore image file!

z:\dos\wtools\x86\imagex /apply z:\img\xp.wim 1 i:
call "z:\dos\wtools\ahci.cmd"

rd I:\Boot /s /q
cd\
bcdboot I:\Windows /s i: /f bios