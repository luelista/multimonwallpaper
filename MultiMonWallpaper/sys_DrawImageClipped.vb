Imports System.Runtime.InteropServices

Module sys_DrawImageClipped

  Sub DrawImageUnscaledAndCentered(ByVal img As Image, ByVal g As Graphics, ByVal targetRect As Rectangle)
    Dim tX, tY As Integer, s As Rectangle
    If img.Width > targetRect.Width Then
      tX = targetRect.X
      s.X = (img.Width - targetRect.Width) \ 2
      s.Width = targetRect.Width
    Else
      tX = (targetRect.Width - img.Width) \ 2 + targetRect.X
      s.X = 0
      s.Width = img.Width
    End If
    If img.Height > targetRect.Height Then
      tY = targetRect.Y
      s.Y = (img.Height - targetRect.Height) \ 2
      s.Height = targetRect.Height
    Else
      tY = (targetRect.Height - img.Height) \ 2 + targetRect.Y
      s.Y = 0
      s.Height = img.Height
    End If

    'ich hasse GDI

    Dim gSrc = Graphics.FromImage(img)
    Dim origDC = g.GetHdc
    Dim compDC = CreateCompatibleDC(origDC)
    Dim oldObj = SelectObject(compDC, DirectCast(img, Bitmap).GetHbitmap())

    Dim ok = BitBlt(origDC, tX, tY, s.Width, s.Height, compDC, s.X, s.Y, TernaryRasterOperations.SRCCOPY)
    g.ReleaseHdc()
    'gSrc.ReleaseHdc()
    gSrc.Dispose()

    ' warum funktioniert diese Funktion nicht? - das Zielbild ist immer ca. 40% größer als gewünscht
    'g.DrawImage(img, tX, tY, s, GraphicsUnit.Pixel)
  End Sub



  <DllImport("gdi32.dll", SetLastError:=True)> _
  Private Function CreateCompatibleDC(ByVal hRefDC As IntPtr) As IntPtr
  End Function


  ''' <summary>
  '''    Performs a bit-block transfer of the color data corresponding to a
  '''    rectangle of pixels from the specified source device context into
  '''    a destination device context.
  ''' </summary>
  ''' <param name="hdc">Handle to the destination device context.</param>
  ''' <param name="nXDest">The leftmost x-coordinate of the destination rectangle (in pixels).</param>
  ''' <param name="nYDest">The topmost y-coordinate of the destination rectangle (in pixels).</param>
  ''' <param name="nWidth">The width of the source and destination rectangles (in pixels).</param>
  ''' <param name="nHeight">The height of the source and the destination rectangles (in pixels).</param>
  ''' <param name="hdcSrc">Handle to the source device context.</param>
  ''' <param name="nXSrc">The leftmost x-coordinate of the source rectangle (in pixels).</param>
  ''' <param name="nYSrc">The topmost y-coordinate of the source rectangle (in pixels).</param>
  ''' <param name="dwRop">A raster-operation code.</param>
  ''' <returns>
  '''    <c>true</c> if the operation succeeded, <c>false</c> otherwise.
  ''' </returns>
  <DllImport("gdi32.dll")> _
  Public Function BitBlt(ByVal hdc As IntPtr, _
                         ByVal nXDest As Integer, ByVal nYDest As Integer, _
                         ByVal nWidth As Integer, ByVal nHeight As Integer, _
                         ByVal hdcSrc As IntPtr, _
                         ByVal nXSrc As Integer, ByVal nYSrc As Integer, _
                         ByVal dwRop As TernaryRasterOperations) As Boolean
  End Function

  ''' <summary>
  '''     Specifies a raster-operation code. These codes define how the color data for the
  '''     source rectangle is to be combined with the color data for the destination
  '''     rectangle to achieve the final color.
  ''' </summary>
  Enum TernaryRasterOperations As UInteger
    ''' <summary>dest = source</summary>
    SRCCOPY = &HCC0020
    ''' <summary>dest = source OR dest</summary>
    SRCPAINT = &HEE0086
    ''' <summary>dest = source AND dest</summary>
    SRCAND = &H8800C6
    ''' <summary>dest = source XOR dest</summary>
    SRCINVERT = &H660046
    ''' <summary>dest = source AND (NOT dest)</summary>
    SRCERASE = &H440328
    ''' <summary>dest = (NOT source)</summary>
    NOTSRCCOPY = &H330008
    ''' <summary>dest = (NOT src) AND (NOT dest)</summary>
    NOTSRCERASE = &H1100A6
    ''' <summary>dest = (source AND pattern)</summary>
    MERGECOPY = &HC000CA
    ''' <summary>dest = (NOT source) OR dest</summary>
    MERGEPAINT = &HBB0226
    ''' <summary>dest = pattern</summary>
    PATCOPY = &HF00021
    ''' <summary>dest = DPSnoo</summary>
    PATPAINT = &HFB0A09
    ''' <summary>dest = pattern XOR dest</summary>
    PATINVERT = &H5A0049
    ''' <summary>dest = (NOT dest)</summary>
    DSTINVERT = &H550009
    ''' <summary>dest = BLACK</summary>
    BLACKNESS = &H42
    ''' <summary>dest = WHITE</summary>
    WHITENESS = &HFF0062
    ''' <summary>
    ''' Capture window as seen on screen.  This includes layered windows 
    ''' such as WPF windows with AllowsTransparency="true"
    ''' </summary>
    CAPTUREBLT = &H40000000
  End Enum

  <DllImport("Gdi32.dll")> _
  Public Function SelectObject(ByVal hdc As IntPtr, ByVal hObject As IntPtr) As IntPtr
  End Function


End Module
