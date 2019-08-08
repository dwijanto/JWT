Imports System.IdentityModel
Imports System.Security
Imports System.Text
Imports Microsoft.IdentityModel.Tokens
Imports System.IdentityModel.Tokens.Jwt

Public Class Form1
   
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim key = "LieDwiJantoJohanLieDwiJantoJohan"
        Dim securitykey = New Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
        Dim credentials = New Microsoft.IdentityModel.Tokens.SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256)
        Dim header = New JwtHeader(credentials)

        Dim payload = New JwtPayload From {{"role", "todo_user"}, {"email", "hello@abc.com"}}
        'Dim payload = New JwtPayload From {{"role", "web_anon"}}
        Dim secToken = New JwtSecurityToken(header, payload)
        Dim handler = New JwtSecurityTokenHandler()

        Dim tokenString = handler.WriteToken(secToken)
        MessageBox.Show(tokenString)
        Dim token = handler.ReadJwtToken(tokenString)
        MessageBox.Show(token.Payload.First().Value)

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
