Module sys_changeBackgroundImage

  Private Declare Function SystemParametersInfo Lib "user32" Alias "SystemParametersInfoA" (ByVal uAction As Integer, _
   ByVal uParam As Integer, ByVal lpvParam As String, _
   ByVal fuWinIni As Integer) As Integer
  Private SPI_SETDESKWALLPAPER As UInt32 = 20
  Private SPIF_UPDATEINIFILE As UInt32 = &H1
  




  Public Sub changeSystemWallpaper(ByVal fileSpec As String)
    SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, fileSpec, SPIF_UPDATEINIFILE)
  End Sub



End Module
