Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Windows.Forms.VisualStyles

''' <summary>
''' A Aero glass Form.
''' Warning: Form BackColor most be Black!
''' Do not use Buttons.
''' If you want use Textbox,change BackColor to Black and ForeColor to Whte.
''' Change all BackColors to transparent (Ecept TextBoxes.) 
''' All Rights Reserved.
''' Fix soft 2010
''' www.FixOSoft.wordpress.com
''' By FeryFM.
''' </summary>
Public Class AeroForm
#Region "AeroForm"
#Region "AutoChanges"
    Dim RealBackGroundImage As Image
    ''' <summary>
    ''' Gets or sets Is Automatical change AeroBackgound to True when Aero is Enable?
    ''' </summary>
    <Description("Is Automatical change AeroBackgound to True when Aero is Enable?"), Category("Aero"), DefaultValue(True)>
    Public Property AutoAeroChange As Boolean = True
    Private Sub FrmHyperGrahic_AeroEffectDisabled(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.AeroEffectDisabled
        If DesignMode Then
            Exit Sub
        End If
        If AutoAeroChange Then
            Me.BackgroundImage = RealBackGroundImage
        End If
    End Sub
    Private Sub FrmHyperGrahic_AeroEffectEnabled(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.AeroEffectEnabled
        If DesignMode Then
            Exit Sub
        End If
        If AutoAeroChange Then
            ResetAeroGlass()
        End If
    End Sub
#End Region
#Region "Properties"
    Private IsGlassEnabled As Boolean
    ''' <summary>
    ''' Gets is Aero Glass Enabled.
    ''' </summary>
    <Description("Is Aero Glass Enabled?"), Category("Aero"), DefaultValue(True)>
    Public Property AeroEnabled() As Boolean
        Get
            Dim VistaOrAbove As Boolean = (Environment.OSVersion.Version.Major >= 6)

            If VistaOrAbove Then
                Dim Enabled As Boolean
                AeroAPIs.DwmIsCompositionEnabled(Enabled)
                Return Enabled
            Else
                Return False
            End If

        End Get
        Set(ByVal value As Boolean)
            If DesignMode Then
                Exit Property
            End If
            Try
                AeroAPIs.DwmEnableComposition(value)
            Catch ex As Exception

            End Try
        End Set
    End Property
    ''' <summary>
    ''' Gets or sets Labels Glow Value.
    ''' </summary>
    <Description("Sets Labels Glow Value."), Category("Aero"), DefaultValue(9)>
    Public Property GlowValue As Integer = 9
    ''' <summary>
    ''' Gets or sets Is Automatical call ShowLabel for Labels?
    ''' It can be slow in big forms.
    ''' </summary>
    <Description("Is Automatical call ShowLabel for Labels?" + vbNewLine + "It can be slow in big forms."), Category("Aero"), DefaultValue(True)>
    Public Property AutoShowLabels As Boolean = True
    ''' <summary>
    ''' Gets Current Aero Color.
    ''' </summary>
    <Description("Current Aero Color."), Category("Aero")>
    Public Shared ReadOnly Property CurrentAeroColor As Color
        Get
            Dim AARRGGBB = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "ColorizationColor", "00000000")
            Dim Argb As Integer = Convert.ToInt32(CLng(AARRGGBB.ToString), 10)
            Return System.Drawing.Color.FromArgb(Argb)
        End Get
    End Property
    ''' <summary>
    ''' Gets or sets Aero Glass Enabled.
    ''' If you changed this property,You need to wait for a restart to changes applied.If you don't like waiting,you most change AeroEnabled to False and then change AeroEnabled to True.
    ''' </summary>
    <Description("Aero Glass Enabled."), Category("Aero"), DefaultValue(True)>
    Public Property AeroGlassEnabled As Boolean
        Get
            Dim GlassEnable = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "ColorizationOpaqueBlend", "00000001")
            Dim GlassEnabled As Boolean
            If GlassEnable = 0 Then
                GlassEnabled = True
            Else
                GlassEnabled = False
            End If
            Return GlassEnabled
        End Get
        Set(ByVal value As Boolean)
            Dim AeroValue As String
            If value Then
                AeroValue = "00000000"
            Else
                AeroValue = "00000001"
            End If
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "ColorizationOpaqueBlend", AeroValue, Microsoft.Win32.RegistryValueKind.DWord)
        End Set
    End Property
#End Region
#Region "AeroEvents"

    ''' <summary>
    ''' Occurs when Areo Turn on.
    ''' </summary>
    <Description("Occurs when Areo Turn on."), Category("Aero")>
    Public Event AeroEffectEnabled(ByVal sender As Object, ByVal e As EventArgs)
    ''' <summary>
    ''' Occurs when Areo Turn off.
    ''' </summary>
    <Description("Occurs when Areo Turn off."), Category("Aero")>
    Public Event AeroEffectDisabled(ByVal sender As Object, ByVal e As EventArgs)
    ''' <summary>
    ''' Occurs when Aero Color changed.
    ''' </summary>
    ''' <param name="Sender">Gets Sender.</param>
    ''' <param name="NewColor">Gets New Color of Aero.</param>
    <Description("Occurs when Aero Color changed."), Category("Aero")>
    Public Event AeroColorOrGlassChanged(ByVal Sender As Object, ByVal NewColor As Color, ByVal GlassEnabled As Boolean)
    Private WithEvents WindowListener As New HookWindow

    Private Sub WindowListener_ColorChanged() Handles WindowListener.ColorChanged
        Dim AARRGGBB = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "ColorizationColor", "00000000")
        Dim Argb As Integer = Convert.ToInt32(CLng(AARRGGBB.ToString), 10)
        Dim NewColor As Color = System.Drawing.Color.FromArgb(Argb)
        Dim GlassEnable = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "ColorizationOpaqueBlend", "00000001")
        Dim GlassEnabled As Boolean
        If GlassEnable = 0 Then
            GlassEnabled = True
        Else
            GlassEnabled = False
        End If
        RaiseEvent AeroColorOrGlassChanged(Me, NewColor, GlassEnabled)
    End Sub
    Private Sub WindowListener_MessageArrived(ByVal sender As Object, ByVal e As System.EventArgs) Handles WindowListener.MessageArrived
        Dim State As Boolean = AeroEnabled
        If State = True AndAlso IsGlassEnabled = False Then
            RaiseEvent AeroEffectEnabled(Me, New EventArgs)
        ElseIf State = False AndAlso IsGlassEnabled = True Then
            RaiseEvent AeroEffectDisabled(Me, New EventArgs)
        End If
        IsGlassEnabled = State
    End Sub
    Public Class HookWindow
        Inherits NativeWindow

        Sub New()
            Dim cp As New CreateParams()
            Me.CreateHandle(cp)
        End Sub

        Public Event MessageArrived(ByVal sender As Object, ByVal e As EventArgs)
        Public Event ColorChanged()
        Private Const WM_SYSCOLORCHANGE As Int32 = &H31E '&H15
        Private Const WM_DWMNCRENDERINGCHANGED As Integer = &H31F
        Private Const WM_DWMCOLORIZATIONCOLORCHANGED As Integer = 800
        Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
            If m.Msg = WM_SYSCOLORCHANGE Or m.Msg = WM_DWMNCRENDERINGCHANGED Then
                RaiseEvent MessageArrived(Me, New EventArgs)
            End If
            If m.Msg = WM_DWMCOLORIZATIONCOLORCHANGED Then
                RaiseEvent ColorChanged()
            End If
            MyBase.WndProc(m)
        End Sub

        Protected Overrides Sub Finalize()
            Me.DestroyHandle()
            MyBase.Finalize()
        End Sub
    End Class

#End Region
#Region "Subs"
    ''' <summary>
    ''' Call DwmExtendFrameIntoClientArea with nagetive numbers and set backcolor to black.
    ''' </summary>
    Sub ResetAeroGlass()
        If AeroEnabled = False Then
            Exit Sub
        End If
        Me.BackgroundImage = Nothing
        Dim margins As New AeroAPIs.MARGINS
        margins.Left = -1
        margins.Right = -1
        margins.Top = -1
        margins.Bottom = -1
        Dim hwnd As IntPtr = Handle
        Dim result As Integer = AeroAPIs.DwmExtendFrameIntoClientArea(hwnd, margins)
        Me.BackColor = Color.Black
    End Sub
    ''' <summary>
    ''' Many controls doesn't support Aero Frame.
    ''' </summary>
    ''' <param name="Control" >Control that be except.</param>
    ''' <param name="InValue" >A number except go in.</param>
    Sub ExceptFromAero(ByVal Control As Control, Optional ByVal InValue As Integer = 3)
        If AeroEnabled = False Then
            Exit Sub
        End If
        Me.BackgroundImage = Nothing
        Dim ClientScreen As Rectangle = Me.RectangleToScreen(Me.ClientRectangle)
        Dim ControlScreen As Rectangle = Control.RectangleToScreen(Control.ClientRectangle)
        Dim margins As New AeroAPIs.MARGINS
        margins.Left = ControlScreen.Left - ClientScreen.Left + InValue
        margins.Right = ClientScreen.Right - ControlScreen.Right + InValue
        margins.Top = ControlScreen.Top - ClientScreen.Top + InValue
        margins.Bottom = ClientScreen.Bottom - ControlScreen.Bottom + InValue
        Dim hwnd As IntPtr = Handle
        Dim result As Integer = AeroAPIs.DwmExtendFrameIntoClientArea(hwnd, margins)
        Me.BackColor = Color.Black
    End Sub
    Public Sub DrawTextGlow(ByVal Graphics As Graphics, ByVal text As String, ByVal fnt As Font, ByVal bounds As Rectangle, ByVal Clr As Color, ByVal flags As TextFormatFlags)

        ' Variables used later.
        Dim SavedBitmap As IntPtr = IntPtr.Zero
        Dim SavedFont As IntPtr = IntPtr.Zero
        Dim MainHDC As IntPtr = Graphics.GetHdc
        Dim MemHDC As IntPtr = AeroAPIs.CreateCompatibleDC(MainHDC)
        Dim BtmInfo As New AeroAPIs.BITMAPINFO
        Dim TextRect As New AeroAPIs.RECT(0, 0, bounds.Right - bounds.Left + 2 * 15, bounds.Bottom - bounds.Top + 2 * 15)
        Dim ScreenRect As New AeroAPIs.RECT(bounds.Left - 15, bounds.Top - 15, bounds.Right + 15, bounds.Bottom + 15)
        Dim hFont As IntPtr = fnt.ToHfont

        Try
            Dim Renderer As VisualStyleRenderer = New VisualStyleRenderer(System.Windows.Forms.VisualStyles.VisualStyleElement.Window.Caption.Active)

            ' Memory bitmap to hold the drawn glowed text.
            BtmInfo.bmiHeader.biSize = Marshal.SizeOf(BtmInfo.bmiHeader)

            With BtmInfo
                .bmiHeader.biWidth = bounds.Width + 30
                .bmiHeader.biHeight = -bounds.Height - 30
                .bmiHeader.biPlanes = 1
                .bmiHeader.biBitCount = 32
            End With

            ' Create a DIB Section for this bitmap from the graphics object.
            Dim dibSection As IntPtr = AeroAPIs.CreateDIBSection(MainHDC, BtmInfo, 0, 0, IntPtr.Zero, 0)

            ' Save the current handles temporarily.
            SavedBitmap = AeroAPIs.SelectObject(MemHDC, dibSection)
            SavedFont = AeroAPIs.SelectObject(MemHDC, hFont)

            ' Holds the properties of the text (size and color , ...etc).
            Dim TextOptions As AeroAPIs.S_DTTOPTS = New AeroAPIs.S_DTTOPTS

            With TextOptions
                .dwSize = Marshal.SizeOf(TextOptions)
                .dwFlags = AeroAPIs.DTT_COMPOSITED Or AeroAPIs.DTT_GLOWSIZE Or AeroAPIs.DTT_TEXTCOLOR
                .crText = ColorTranslator.ToWin32(Clr)
                .iGlowSize = GlowValue
            End With

            ' Draw The text on the memory surface.
            AeroAPIs.DrawThemeTextEx(Renderer.Handle, MemHDC, 0, 0, text, -1, flags, TextRect, TextOptions)

            ' Reflecting the image on the primary surface of the graphics object.
            With ScreenRect
                AeroAPIs.BitBlt(MainHDC, .Left, .Top, .Right - .Left, .Bottom - .Top, MemHDC, 0, 0, AeroAPIs.SRCCOPY)
            End With

            ' Resources Cleaning.
            AeroAPIs.SelectObject(MemHDC, SavedFont)
            AeroAPIs.SelectObject(MemHDC, SavedBitmap)

            AeroAPIs.DeleteDC(MemHDC)
            AeroAPIs.DeleteObject(hFont)
            AeroAPIs.DeleteObject(dibSection)

            Graphics.ReleaseHdc(MainHDC)
        Catch ex As Exception

        End Try
    End Sub
    Dim Labels(-1) As Label
    Sub ShowLabel(ByVal Label As Label)
        Array.Resize(Of Label)(Labels, Labels.Length + 1)
        Labels(Labels.Length - 1) = Label
    End Sub
    Public Property TextDrawAlign As TextFormatFlags = TextFormatFlags.VerticalCenter Or TextFormatFlags.HorizontalCenter Or TextFormatFlags.NoPrefix Or TextFormatFlags.SingleLine
    Private Sub Parent_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        If AeroEnabled = False Then
            Exit Sub
        End If
        For Each Label As Label In Labels
            Label.Visible = False
            DrawTextGlow(e.Graphics, Label.Text, Label.Font, Label.Bounds, Label.ForeColor, TextDrawAlign)
        Next
    End Sub
#End Region
    Public Class AeroAPIs
        <DllImport("dwmapi.dll", PreserveSig:=False)> _
        Public Shared Function DwmEnableComposition(ByVal bEnable As Boolean)
        End Function
        <DllImport("dwmapi.dll", PreserveSig:=False)> _
        Public Shared Function DwmEnableBlurBehindWindow(ByVal hWnd As IntPtr, ByVal pBlurBehind As Dwm_BlurBehind) As Integer
        End Function
        <DllImport("dwmapi.dll", PreserveSig:=False)> _
        Public Shared Function DwmGetColorizationColor(ByVal pcrColorization As Integer, <MarshalAs(UnmanagedType.Bool)> ByVal pfOpaqueBlend As Boolean)
        End Function
        <DllImport("dwmapi.dll", PreserveSig:=False)> _
        Public Shared Function DwmRegisterThumbnail(ByVal dest As IntPtr, ByVal source As IntPtr) As IntPtr
        End Function
        <DllImport("dwmapi.dll", PreserveSig:=False)> _
        Public Shared Function DwmUnregisterThumbnail(ByVal hThumbnail As IntPtr)
        End Function
        <DllImport("dwmapi.dll", PreserveSig:=False)> _
        Public Shared Function DwmUpdateThumbnailProperties(ByVal hThumbnail As IntPtr, ByVal props As Dwm_ThumbnailProperties)
        End Function
        <DllImport("dwmapi.dll", PreserveSig:=False)> _
        Public Shared Function DwmQueryThumbnailSourceSize(ByVal hThumbnail As IntPtr, ByVal size As Size)
        End Function
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure Dwm_ThumbnailProperties
            Public dwFlags As UInt64
            Public rcDestination As RECT
            Public rcSource As RECT
            Public opacity As Byte
            <MarshalAs(UnmanagedType.Bool)> _
            Public fVisible As Boolean
            <MarshalAs(UnmanagedType.Bool)> _
            Public fSourceClientAreaOnly As Boolean
            Public Const DWM_TNP_RECTDESTINATION As UInt32 = &H1
            Public Const DWM_TNP_RECTSOURCE As UInt32 = &H2
            Public Const DWM_TNP_OPACITY As UInt32 = &H4
            Public Const DWM_TNP_VISIBLE As UInt32 = &H8
            Public Const DWM_TNP_SOURCECLIENTAREAONLY As UInt32 = &H10
        End Structure
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure Dwm_BlurBehind
            Public dwFlags As UInt64
            <MarshalAs(UnmanagedType.Bool)> _
            Public fEnable As Boolean
            Public hRegionBlur As IntPtr
            <MarshalAs(UnmanagedType.Bool)> _
            Public fTransitionOnMaximized As Boolean
            Public Const DWM_BB_ENABLE As UInt32 = &H1
            Public Const DWM_BB_BLURREGION As UInt32 = &H2
            Public Const DWM_BB_TRANSITIONONMAXIMIZED As UInt32 = &H4
        End Structure
        Public Declare Function CreateDIBSection Lib "gdi32.dll" (ByVal hdc As IntPtr, ByRef pbmi As BITMAPINFO, ByVal iUsage As UInt32, ByVal ppvBits As Integer, ByVal hSection As IntPtr, ByVal dwOffset As UInt32) As IntPtr
        Public Declare Function CreateCompatibleDC Lib "gdi32.dll" (ByVal hDC As IntPtr) As IntPtr
        Public Declare Function SelectObject Lib "gdi32.dll" (ByVal hDC As IntPtr, ByVal hObject As IntPtr) As IntPtr
        Public Declare Function DeleteObject Lib "gdi32.dll" (ByVal hObject As IntPtr) As Boolean
        Public Declare Function DeleteDC Lib "gdi32.dll" (ByVal hdc As IntPtr) As Boolean
        Public Declare Function BitBlt Lib "gdi32.dll" (ByVal hdc As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As Int32) As Boolean

        Public Declare Function DwmExtendFrameIntoClientArea Lib "dwmapi.dll" (ByVal hWnd As IntPtr, ByRef margins As MARGINS) As Integer
        Public Declare Sub DwmIsCompositionEnabled Lib "dwmapi.dll" (ByRef IsIt As Boolean)
        <DllImport("UxTheme.dll", ExactSpelling:=True, SetLastError:=True, CharSet:=CharSet.Unicode)> Shared Function DrawThemeTextEx(ByVal hTheme As IntPtr, ByVal hdc As IntPtr, ByVal iPartId As Integer, ByVal iStateId As Integer, ByVal text As String, ByVal iCharCount As Integer, ByVal dwFlags As Integer, ByRef pRect As RECT, ByRef pOptions As S_DTTOPTS) As Integer
        End Function

        Public Const DTT_COMPOSITED As Integer = 8192
        Public Const DTT_GLOWSIZE As Integer = 2048
        Public Const DTT_TEXTCOLOR As Integer = 1
        Public Const SRCCOPY As Integer = &HCC0020
        Public Const WM_SYSCOLORCHANGE As Int32 = &H15

        <StructLayout(LayoutKind.Sequential)> _
        Public Structure MARGINS
            Public Left As Integer
            Public Right As Integer
            Public Top As Integer
            Public Bottom As Integer
        End Structure

        Public Structure RECT

            Public Sub New(ByVal iLeft As Integer, ByVal iTop As Integer, ByVal iRight As Integer, ByVal iBottom As Integer)
                Left = iLeft
                Top = iTop
                Right = iRight
                Bottom = iBottom
            End Sub

            Public Left As Integer
            Public Top As Integer
            Public Right As Integer
            Public Bottom As Integer
        End Structure

        Public Structure BITMAPINFOHEADER
            Dim biSize As Integer
            Dim biWidth As Integer
            Dim biHeight As Integer
            Dim biPlanes As Short
            Dim biBitCount As Short
            Dim biCompression As Integer
            Dim biSizeImage As Integer
            Dim biXPelsPerMeter As Integer
            Dim biYPelsPerMeter As Integer
            Dim biClrUsed As Integer
            Dim biClrImportant As Integer
        End Structure

        Public Structure RGBQUAD
            Dim rgbBlue As Byte
            Dim rgbGreen As Byte
            Dim rgbRed As Byte
            Dim rgbReserved As Byte
        End Structure

        Public Structure BITMAPINFO
            Dim bmiHeader As BITMAPINFOHEADER
            Dim bmiColors As RGBQUAD
        End Structure

        Public Structure S_DTTOPTS
            Dim dwSize As Integer
            Dim dwFlags As Integer
            Dim crText As Integer
            Dim crBorder As Integer
            Dim crShadow As Integer
            Dim iTextShadowType As Integer
            Dim ptShadowOffset As Point
            Dim iBorderSize As Integer
            Dim iFontPropId As Integer
            Dim iColorPropId As Integer
            Dim iStateId As Integer
            Dim fApplyOverlay As Boolean
            Dim iGlowSize As Integer
            Dim pfnDrawTextCallback As Integer
            Dim lParam As IntPtr
        End Structure

        Public Class HookWindow
            Inherits NativeWindow

            Sub New()
                Dim cp As New CreateParams()
                Me.CreateHandle(cp)
            End Sub

            Public Event MessageArrived(ByVal sender As Object, ByVal e As EventArgs)

            Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

                If m.Msg = AeroAPIs.WM_SYSCOLORCHANGE Then
                    RaiseEvent MessageArrived(Me, New EventArgs)
                End If

                MyBase.WndProc(m)

            End Sub

            Protected Overrides Sub Finalize()
                Me.DestroyHandle()
                MyBase.Finalize()
            End Sub
        End Class

    End Class
#End Region
    Private Sub AeroForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '<AeroNeed>
        'This call is required by Fix soft error.
        'If you delete it,Aero doesn't work.
        RealBackGroundImage = Me.BackgroundImage
        ResetAeroGlass()
        If AutoShowLabels Then
            For Each Control In Controls
                If TypeOf Control Is Label Then
                    ShowLabel(Control)
                End If
            Next
        End If
        '</AeroNeed>
    End Sub
End Class
