Imports System.Globalization
Imports System.Net
Imports System.Text

''' <summary>
''' Internal module for functions needed for the API call.
''' </summary>
Friend Module APIUtil
    ''' <summary>
    ''' Calls the API and downloads the JSON string of its response given an API-url.
    ''' </summary>
    ''' <param name="url">Url of the API-call.</param>
    ''' <returns>The response string of the API-call in JSON format.</returns>
    Public Function GetResponse(url As String) As String
        Dim result As String = String.Empty

        Using webClient As New WebClient()
            webClient.Encoding = Encoding.UTF8
            result = webClient.DownloadString(url)
        End Using

        Return result
    End Function

    ''' <summary>
    ''' Builds the url for the API call given its optional parameters.
    ''' </summary>
    ''' <param name="baseUrl">Base url of the API.</param>
    ''' <param name="gender">The gender of the person(s) to be generated.</param>
    ''' <param name="region">The region of the person(s) to be generated.</param>
    ''' <param name="minLen">The minimal length of the persons' names.</param>
    ''' <param name="maxLen">The maximum length of the persons' names.</param>
    ''' <param name="amount">Amount of names to be generated.</param>
    ''' <returns>The full url that is to be used for the API call.</returns>
    Public Function BuildUrl(baseUrl As String, Optional gender As Gender = Gender.NotSpecified,
                             Optional region As RegionInfo = Nothing, Optional minLen? As Integer = Nothing,
                             Optional maxLen? As Integer = Nothing, Optional amount? As UShort = Nothing) As String
        Dim parameters As New List(Of String)
        Dim parmString As String = String.Empty

        If Not amount Is Nothing Then
            parameters.Add($"amount={amount}")
        End If
        If Not gender = Gender.NotSpecified Then
            parameters.Add($"gender={[Enum].GetName(gender.GetType(), gender).ToLower()}")
        End If
        If Not region Is Nothing Then
            parameters.Add($"region={region.EnglishName.ToLower()}")
        End If
        If Not minLen Is Nothing Then
            parameters.Add($"minLen={minLen}")
        End If
        If Not maxLen Is Nothing Then
            parameters.Add($"maxLen={maxLen}")
        End If

        If parameters.Count > 0 Then
            parmString = $"/?{String.Join("&", parameters)}"
        End If

        Return $"{baseUrl}{parmString}"
    End Function
End Module
