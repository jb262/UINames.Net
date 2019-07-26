Imports Newtonsoft.Json

''' <summary>
''' Very basic information on a person's name.
''' </summary>
Public Class Name
    ''' <summary>
    ''' The person's first name.
    ''' </summary>
    <JsonProperty("name")>
    Public Name As String
    ''' <summary>
    ''' The person's last name.
    ''' </summary>
    <JsonProperty("surname")>
    Public Surname As String
    ''' <summary>
    ''' The person's gender.
    ''' </summary>
    <JsonProperty("gender")>
    Public Gender As String
    ''' <summary>
    ''' The region name the person is coming from.
    ''' </summary>
    <JsonProperty("region")>
    Public Region As String
End Class

''' <summary>
''' Enum for a person's gender. Other genders than female or male are not supported by uinames.org.
''' </summary>
Public Enum Gender
    NotSpecified
    Female
    Male
End Enum
