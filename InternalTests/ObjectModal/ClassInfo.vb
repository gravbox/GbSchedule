Imports System.Reflection
Imports System

Public Class ClassInfo

  Public Function GetClassInfo(ByVal t As Type) As String

    Dim retval As String = ""

    Try
      'we're not interested in primitives or value types
      If (t.IsClass) Then

        retval &= t.FullName & "  " & t.BaseType.ToString & "  "

        'Print out some class level info
        If (t.IsAbstract) Then retval &= "Abstract "
        If (t.IsPublic) Then retval &= "Public "
        If (t.IsSealed) Then retval &= "Sealed "
        If (t.IsSerializable) Then retval &= "Serializable "

        'get the library name and assmebly info
        retval &= "\nContained in " & t.Namespace
        retval &= "Assembly info is: \n" & t.Assembly.ToString

        'Get Constructors
        Dim ctrInfo As ConstructorInfo() = t.GetConstructors()
        Dim c As ConstructorInfo
        retval &= "Constructors\n"
        For Each c In ctrInfo
          retval &= c.ToString() & "\n"
        Next
        retval &= "\n"

        'Get Properties
        Dim pInfo As PropertyInfo() = t.GetProperties()
        Dim prop As PropertyInfo
        retval &= "Properties\n"
        For Each prop In pInfo
          retval &= prop.ToString() & "\n"
        Next
        retval &= "\n"

        'Get an array representing the methods of this class
        Dim methods As MethodInfo() = t.GetMethods
        Dim m As MethodInfo
        For Each m In methods

          'get some info about each method
          retval &= "\nMethod:\n"
          If (m.IsPublic) Then retval &= "Public "
          If (m.IsPrivate) Then retval &= "Private "
          If (m.IsAbstract) Then retval &= "Abstract "
          If (m.IsConstructor) Then retval &= "Constructor "
          If (m.IsFinal) Then retval &= "Final "

          retval &= m.ReturnType.ToString() & " " & m.Name
          retval &= "Parameters:"

          'if this method has any parameters,
          'list out some info about each
          Dim pi As ParameterInfo() = m.GetParameters()
          If (pi.Length = 0) Then
            retval &= "\nNone"
          Else

            Dim p As ParameterInfo
            For Each p In pi

              retval &= "\n"


              If (p.IsOut) Then
                retval &= "out "
                retval &= p.ParameterType.ToString() & "  p.Name"
              End If
            Next
          End If
        Next
      End If

      retval = retval.Replace("\n", ControlChars.CrLf)
      Return retval

    Catch
      Beep()
    End Try

  End Function

End Class

