WinWait("Open","",15)

ControlFocus("Open","","Edit1")

ControlSetText("Open","","Edit1",$cmdline[1])

ControlClick("Open","","Button1")