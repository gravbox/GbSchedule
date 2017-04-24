Imports System.Reflection
'Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("Gravitybox Schedule.NET")> 
<Assembly: AssemblyCopyright("Gravitybox Copyright © 1998-2006")> 
<Assembly: AssemblyCompany("Gravitybox Software")> 
<Assembly: AssemblyProduct("Gravitybox Schedule.NET")> 
<Assembly: AssemblyTrademark("Warning: This program is protected by copyright law and international treaties. Unauthorized reproduction or distribution of this program, or any portion of it, may result in severe civil and criminal penalties and will be prosecuted to the maximum extent possible under law.")> 
<Assembly: CLSCompliant(True)> 

#If SHAREWARE = 1 And DEBUG Then
<Assembly: AssemblyDescription("Gravitybox Schedule.NET is a general purpose enterprise scheduling component." & vbCrLf & "(Demo Debug Version)")> 
#ElseIf SHAREWARE = 1 And Not DEBUG Then
<Assembly: AssemblyDescription("Gravitybox Schedule.NET is a general purpose enterprise scheduling component."  & vbCrLf & "(Demo Version)")> 
#ElseIf SHAREWARE = 0 And DEBUG Then
<Assembly: AssemblyDescription("Gravitybox Schedule.NET is a general purpose enterprise scheduling component." & vbCrLf & "(Debug Version)")> 
#ElseIf SHAREWARE = 0 And Not DEBUG Then
<Assembly: AssemblyDescription("Gravitybox Schedule.NET is a general purpose enterprise scheduling component.")> 
#End If
