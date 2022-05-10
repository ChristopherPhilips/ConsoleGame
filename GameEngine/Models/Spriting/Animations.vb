Imports Newtonsoft.Json
Public Class Animations
    <JsonProperty("init")> Public Property initFrame As Frame 'this is the last step in breaking down the json
    <JsonProperty("animations")> Public Property animations As Dictionary(Of String, List(Of Frame)) 'after list put Dictionary(Of String, List(Of String))
End Class