﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On




Partial Friend NotInheritable Class Settings1
    Inherits Global.System.Configuration.ApplicationSettingsBase



    Public Shared ReadOnly Property [Default]() As Settings1
        Get
            Return defaultInstance
        End Get
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("")>  _
    Public ReadOnly Property Setting() As String
        Get
            Return CType(Me("Setting"),String)
        End Get
    End Property
End Class