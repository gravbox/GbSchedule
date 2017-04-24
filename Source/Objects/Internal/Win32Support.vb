#Region "Copyright (c) 1998-2007 Gravitybox LLC, All Rights Reserved"
'--------------------------------------------------------------------- *
'                          Gravitybox  LLC                             *
'             Copyright (c) 1998-2007 All Rights reserved              *
'                                                                      *
'                                                                      *
'This file and its contents are protected by United States and         *
'International copyright laws.  Unauthorized reproduction and/or       *
'distribution of all or any portion of the code contained herein       *
'is strictly prohibited and will result in severe civil and criminal   *
'penalties.  Any violations of this copyright will be prosecuted       *
'to the fullest extent possible under law.                             *
'                                                                      *
'THE SOURCE CODE CONTAINED HEREIN AND IN RELATED FILES IS PROVIDED     *
'TO THE REGISTERED DEVELOPER FOR THE PURPOSES OF EDUCATION AND         *
'TROUBLESHOOTING. UNDER NO CIRCUMSTANCES MAY ANY PORTION OF THE SOURCE *
'CODE BE DISTRIBUTED, DISCLOSED OR OTHERWISE MADE AVAILABLE TO ANY     *
'THIRD PARTY WITHOUT THE EXPRESS WRITTEN CONSENT OF Gravitybox LLC    *
'                                                                      *
'UNDER NO CIRCUMSTANCES MAY THE SOURCE CODE BE USED IN WHOLE OR IN     *
'PART, AS THE BASIS FOR CREATING A PRODUCT THAT PROVIDES THE SAME, OR  *
'SUBSTANTIALLY THE SAME, FUNCTIONALITY AS ANY GRAVITYBOX PRODUCT.      *
'                                                                      *
'THE REGISTERED DEVELOPER ACKNOWLEDGES THAT THIS SOURCE CODE           *
'CONTAINS VALUABLE AND PROPRIETARY TRADE SECRETS OF GRAVITYBOX,        *
'INC.  THE REGISTERED DEVELOPER AGREES TO EXPEND EVERY EFFORT TO       *
'INSURE ITS CONFIDENTIALITY.                                           *
'                                                                      *
'THE END USER LICENSE AGREEMENT (EULA) ACCOMPANYING THE PRODUCT        *
'PERMITS THE REGISTERED DEVELOPER TO REDISTRIBUTE THE PRODUCT IN       *
'EXECUTABLE FORM ONLY IN SUPPORT OF APPLICATIONS WRITTEN USING         *
'THE PRODUCT.  IT DOES NOT PROVIDE ANY RIGHTS REGARDING THE            *
'SOURCE CODE CONTAINED HEREIN.                                         *
'                                                                      *
'THIS COPYRIGHT NOTICE MAY NOT BE REMOVED FROM THIS FILE.              *
'--------------------------------------------------------------------- *
#End Region

Option Strict On
Option Explicit On 

Imports System.Runtime.InteropServices

'Summary description for Win32Support.
'Win32Support is a wrapper class that imports all the necessary
'functions that are used in old double-buffering technique  
'for smooth animation. 
Friend Class Win32Support

  'Enumeration to be used for those Win32 function that return BOOL
  Friend Enum Bool
    FFalse = 0
    TTrue = 1
  End Enum

  'Enumeration for the raster operations used in BitBlt.
  'In C++ these are actually #define. But to use these
  'constants with C#, a new enumeration type is defined.
  Friend Enum TernaryRasterOperations
    SRCCOPY = &HCC0020       'dest = source                   
    SRCPAINT = &HEE0086      'dest = source OR dest           
    SRCAND = &H8800C6        'dest = source AND dest          
    SRCINVERT = &H660046     'dest = source XOR dest          
    SRCERASE = &H440328      'dest = source AND (NOT dest )   
    NOTSRCCOPY = &H330008    'dest = (NOT source)             
    NOTSRCERASE = &H1100A6   'dest = (NOT src) AND (NOT dest) 
    MERGECOPY = &HC000CA     'dest = (source AND pattern)     
    MERGEPAINT = &HBB0226    'dest = (NOT source) OR dest     
    PATCOPY = &HF00021       'dest = pattern                  
    PATPAINT = &HFB0A09      'dest = DPSnoo                   
    PATINVERT = &H5A0049     'dest = pattern XOR dest         
    DSTINVERT = &H550009     'dest = (NOT dest)               
    BLACKNESS = &H42         'dest = BLACK                    
    WHITENESS = &HFF0062     'dest = WHITE                    
  End Enum

  <DllImport("gdi32.dll")> _
  Public Shared Function CreatePen(ByVal fnPenStyle As Integer, ByVal width As Integer, ByVal color As Integer) As IntPtr
  End Function

  <DllImport("gdi32.dll")> _
  Public Shared Function SetROP2(ByVal hdc As IntPtr, ByVal rop As Integer) As Integer
  End Function

  <DllImport("gdi32.dll")> _
  Public Shared Function CreateCompatibleDC(ByVal hDC As IntPtr) As IntPtr
  End Function

  <DllImport("gdi32.dll")> _
  Public Shared Function DeleteDC(ByVal hdc As IntPtr) As Bool
  End Function

  <DllImport("gdi32.dll")> _
  Public Shared Function SelectObject(ByVal hDC As IntPtr, ByVal hObject As IntPtr) As IntPtr
  End Function

  <DllImport("gdi32.dll")> _
  Public Shared Function DeleteObject(ByVal hObject As IntPtr) As Bool
  End Function

  <DllImport("gdi32.dll")> _
  Public Shared Function CreateCompatibleBitmap(ByVal hObject As IntPtr, ByVal width As IntPtr, ByVal height As IntPtr) As IntPtr
  End Function

  <DllImport("gdi32.dll")> _
  Public Shared Function BitBlt(ByVal hObject As IntPtr, ByVal nXDest As IntPtr, ByVal nYDest As IntPtr, ByVal nWidth As IntPtr, ByVal nHeight As IntPtr, ByVal hObjSource As IntPtr, ByVal nXSrc As IntPtr, ByVal nYSrc As IntPtr, ByVal dwRop As TernaryRasterOperations) As Bool
  End Function

  <DllImport("gdi32.dll")> _
  Public Shared Function Rectangle(ByVal hdc As IntPtr, ByVal X1 As Integer, ByVal Y1 As Integer, ByVal X2 As Integer, ByVal Y2 As Integer) As IntPtr
  End Function

  <DllImport("gdi32.dll")> _
  Public Shared Function LineTo(ByVal hdc As IntPtr, ByVal x As Integer, ByVal y As Integer) As Integer
  End Function

  <DllImport("gdi32.dll")> _
  Public Shared Function MoveToEx(ByVal hdc As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal lpPoint As Integer) As Integer
  End Function

	<DllImport("user32.dll")> _
	Public Shared Function DestroyIcon(ByVal hIcon As IntPtr) As Bool
	End Function

End Class
