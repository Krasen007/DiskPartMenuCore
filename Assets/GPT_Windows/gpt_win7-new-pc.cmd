@Echo off
diskpart.exe < Y:\_Dido\_DiskpartMenu\GPT_Windows\TXT\gpt_win7pro.txt
Echo Now Ready to restore image file!

z:\dos\wtools\x86\imagex /apply z:\img\7.wim 1 i:
call "x:\dos\wtools\ahci.cmd"

I:
bootsect /nt60 s:
z:\dos\wtools\x86\bcdboot i:\windows /s s: /f uefi

