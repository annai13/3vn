'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class Course
    Public Property CourseID As Integer
    Public Property Title As String
    Public Property Credits As Nullable(Of Integer)

    Public Overridable Property Enrollment As ICollection(Of Enrollment) = New HashSet(Of Enrollment)

End Class
