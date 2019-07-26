Imports System.Globalization
Imports Newtonsoft.Json

''' <summary>
''' Externally callable module containing the functions to retrieve random generated names from uinames.com.
''' </summary>
Public Module NameGenerator
    ''' <summary>
    ''' Base url of the API.
    ''' </summary>
    Private Const baseUrl As String = "https://uinames.com/api"

    ''' <summary>
    ''' Calls the uinames API for a single randomly generated name.
    ''' </summary>
    ''' <param name="gender">Gender of the person's name to be genrated. Optional, random if not specified.</param>
    ''' <param name="region">Region of the person's name to be generated. Optional, random if not specified.</param>
    ''' <param name="minLen">Minimum charachters of the person's name to be generated. Optional, zero if not specified.</param>
    ''' <param name="maxLen">Maximum characters of the person's name to be generated. Optional, unbounded if not specifed.</param>
    ''' <returns>A randomly generated name with the information retrieved from the uinames API.</returns>
    ''' <remarks>Non-Latin names will probably be displayed as some funny characters.</remarks>
    Public Function GetName(Optional gender As Gender = Gender.NotSpecified,
                            Optional region As RegionInfo = Nothing, Optional minLen? As Integer = Nothing,
                            Optional maxLen? As Integer = Nothing) As Name
        Dim url As String = BuildUrl(baseUrl, gender, region, minLen, maxLen)
        Dim response As String = GetResponse(url)
        Dim name As Name = JsonConvert.DeserializeObject(Of Name)(response)

        Return name
    End Function

    ''' <summary>
    ''' Returns an enumerable of a given amount of randomly generated persons' names.
    ''' </summary>
    ''' <param name="amount">Number of names to be generated.</param>
    ''' <param name="gender">Gender of the persons' names to be genrated. Optional, random if not specified.</param>
    ''' <param name="region">Region of the persons' names to be generated. Optional, random if not specified.</param>
    ''' <param name="minLen">Minimum charachters of the persons' names to be generated. Optional, zero if not specified.</param>
    ''' <param name="maxLen">Maximum characters of the persons' names to be generated. Optional, unbounded if not specifed.</param>
    ''' <returns>IEnumerable of type Name containing the specified number of names.</returns>
    ''' <remarks>Non-Latin names will probably be displayed as some funny characters.</remarks>
    Public Function GetNames(amount As UShort, Optional gender As Gender = Gender.NotSpecified,
                            Optional region As RegionInfo = Nothing, Optional minLen? As Integer = Nothing,
                            Optional maxLen? As Integer = Nothing) As IEnumerable(Of Name)
        Dim url As String = BuildUrl(baseUrl, gender, region, minLen, maxLen, amount)
        Dim response As String = GetResponse(url)
        Dim names As IEnumerable(Of Name) = JsonConvert.DeserializeObject(Of IEnumerable(Of Name))(response)

        Return names
    End Function
End Module
