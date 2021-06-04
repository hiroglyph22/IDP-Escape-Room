using System.Collections;
using System.Collections.Generic;
using System.IO;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using UnityEngine;
using static Google.Apis.Sheets.v4.SheetsService;

public static class DataDump
{

    public static bool initialized = false;
    public static string[] Scopes = { Scope.Spreadsheets };
    public static string ApplicationName = "EscapeRoom";
    public static string SpreadsheetID = "1GYfgrsdC5sQS4nuXdJzYDgk7NInkhl4Zxs1J-I4vxQk";
    public static string[] sheets = new string[] { "Sheet1", "Sheet2" };
    public static SheetsService service;
    private static GoogleCredential credential;

    public static void Initialize() {
        string credentialString = Resources.Load("idp-9th-grade-2021-group-5-006d09808b61", typeof(TextAsset)).ToString();
        credential = GoogleCredential.FromJson(credentialString).CreateScoped(Scopes);
        service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer() {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName});
    }

    public static IList<IList<object>> ReadEntries(string rangeLow, string rangeHigh, int index){
        var range = $"{sheets[index]}!{rangeLow}:{rangeHigh}";
        var request = service.Spreadsheets.Values.Get(SpreadsheetID, range);
        var response = request.Execute();
        var values = response.Values;
        return values;
    }

    public static void CreateEntry(string leftColumn, string rightColumn, List<object> inputs, int index) {
        var sheet = sheets[index];
        var range = $"{sheet}!{leftColumn}:{rightColumn}";
        var valueRange = new ValueRange();
        valueRange.Values = new List<IList<object>> {inputs};
        var appendRequest = service.Spreadsheets.Values.Append(valueRange, SpreadsheetID, range);
        appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
        var appendResponse = appendRequest.Execute();
    }

}
