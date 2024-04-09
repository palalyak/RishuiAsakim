using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading;
using FluentAssertions;
using Microsoft.Identity.Client;
using NUnit.Framework;
using RestSharp;

namespace TestProject2
{
    public class FakeApiTests
    {

        
        public void SearchBooks()
        {
            Console.WriteLine($"Clean table [ris_t_haarachat_moed_lemahut]");
            List<string> logs = new List<string>();
            int bakashaIdToUpdate = 110;
            logs.Add($"Bakasha for update: {bakashaIdToUpdate}");

           DateTime startDay = WorkDays.CalcWorksDays(accessToken, 0);
            Submission.UpdateSubmissionDate_DB(bakashaIdToUpdate, startDay);

            RestResponse response2 = request.Post(accessToken, "License/ManagerStationsWorkingProcess");

            var codeParit = RequestItem.GetCodeParit_DB(bakashaIdToUpdate);
            var codeStation = StationsDB.Get(codeParit);
            logs.Add(HaarachatMoedLemahutDB.Delete(codeParit));

            Console.WriteLine($"Clean table [ris_t_atraa_letachana_measheret]");
            logs.Add(AtraaLetachanaMeasheretDB.Delete(codeStation));

            SaveLogsToFile.SaveLog(logs);

        }

        /*private AuthenticationResult _accessToken;*/
        string accessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IlQxU3QtZExUdnlXUmd4Ql82NzZ1OGtyWFMtSSIsImtpZCI6IlQxU3QtZExUdnlXUmd4Ql82NzZ1OGtyWFMtSSJ9.eyJhdWQiOiJhcGk6Ly81M2JmYTAyYy05NDUzLTRmZWItYjAxNy0zOWYwYzczNmZhMjEiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC9hYTY0MGYxMC05NWY4LTRmMDUtOTZmMS01MjlkYmJjMTE4OTcvIiwiaWF0IjoxNzAxMDQxNDI5LCJuYmYiOjE3MDEwNDE0MjksImV4cCI6MTcwMTA0NTMzNCwiYWNyIjoiMSIsImFpbyI6IkFWUUFxLzhWQUFBQWY5MHp1TjhCQ1p3RnZhdHU0WCtSRXVvblpLcWJWWndDcVhpL0l4bzZ4RHpNMGM3MlhsdEozL0lIaVZHMDNLeXNOMTVpS3ByZHp1R2VDVkcwVnVLUmx0RCsyT01xaXYxSjAxOFpvWUtBS3I4PSIsImFtciI6WyJwd2QiLCJtZmEiXSwiYXBwaWQiOiI4MDhjZDhjMi02Mzg2LTRiYjQtYjk5ZC01MWNkYzNjOWQyZTgiLCJhcHBpZGFjciI6IjAiLCJmYW1pbHlfbmFtZSI6Itek15zXplx1MDAyN9eZ16bXp9eZIiwiZ2l2ZW5fbmFtZSI6IteQ15zXm9eh16DXk9eoIiwiZ3JvdXBzIjpbIjFjZTMyNDEwLWJkZmUtNDk0Yi1iZjc0LWE3YmNjY2Q3ZjBkMSIsIjdmNTg3MTE1LWRiMzEtNDM0Yy1hZWFjLTE5MWM5NmY0NDc3OSIsIjMyMGM5MTE4LTE5NTktNDkzZi05ZWNlLWU3ZWVlNmYxMDNiMCIsIjc0MWQ3OTE5LTYyNWMtNGI2OS1hZWRjLThjZjQ4MjZhYWRjNSIsImE0YzlmNDFhLTEzODYtNDczMi1hNTYzLWZkMjNiNzYwOTQ1YiIsImFiMzY4YjFmLTg3NGQtNDQ5NS05ZDVkLTI2MjBkODVmM2NlZiIsIjUxZmNjNTIxLWYwZjgtNDYzOS1iNWI2LWEyMzAxYzVhOTIyZCIsIjA4MTRjODJkLTJkOTQtNDM4OS1iOWU3LTM3ZTczNjQ0ZjQ5NCIsIjc1YjYwZDMyLTFjYzgtNGM2Zi1iM2Q2LTEzN2U1MjY1ZTI5YSIsIjAzYzMyZTM5LWRmMmYtNGVmOC05NTJlLTEzMmVhZTE4MmRhOSIsIjI5NzY1MjNkLWJmOWItNDhlMS04MGUyLTNlNDdkODBmOTY2MCIsImRmNmM1NzQwLWM5ZGYtNGZmMC05OTY5LTQ2OTZiZjkxNzdiNiIsIjU3MDUwNDRkLTIyMGItNDgxNy1iMTdhLWE5MzBlYWMzODdkZiIsIjhhY2RlMTUwLWMxNzAtNGVjYS1iNjg5LTg1NTdkOTEzOWZlZSIsImY3YTM3YjU0LWI2MDgtNGJiZS1iMzIxLTdmZDdjNGY5NTRhNyIsIjIzODk0MTU2LWE3MjEtNGMyZC1hYjUxLTkxMDI4ZDgxZjJlZCIsImZiYTZjNTYyLTkyZjAtNDIwZC1iOTZiLTlkODBiMGM0YTRiNyIsImY1Zjk5NzZkLWZhNTMtNDFmZi1iNWEyLTMzYWQ0ZmNkYzExMyIsImQyNWEwZTc5LTdkOTYtNDNiOS05MTYxLTQ0NTM5OWI5ZDY4YiIsIjg0NTYzZTdiLWJiNTItNDlkMC1iMTNkLWYxYWViZjZlMDExYSIsIjE3YTU4ZjdkLTBjY2ItNDUxMy04MTUwLTQ4MmY0MDYxNGIxMCIsIjBjNTE2NTgxLTE5YmQtNDIwZS1hNWVkLTA3NWIyYmQ5ODJiMyIsIjU3Y2YwODg0LTVlNTQtNDUzOC1hNDg0LTZkMjZjNWRhZmQzMSIsImJjOTBhNTg0LWFmZTItNDA5NC1iMGUxLWQwNDMwYWY2MjQzMiIsImIyZjcxMDg2LTM4ZTAtNDNhYi04YjMxLWY1OWMyZDU5YmM4NyIsIjU5ZWUyNjhmLWE4MWQtNDNkYi04MzczLTdiNjIwZTU3MjU3OSIsIjNmOTA1NWE2LWZmMzQtNDYwYi05MGJiLTEzZDNjYTFjYTlkMSIsImM3MWViMGE3LWJlZmUtNDY3Ny04ZTU1LWI2MjA2MThkMTM4MyIsIjdkYTUxMmE4LTYyYWYtNGI0Ni1hNDA3LWM1NDg1NGE1YWUyNCIsIjI0ZGJkM2E4LWJlZmUtNDNiMS05NDhjLWQ4MjBhNjY2ZmJmZiIsImUwMzNmYWFjLTFjNzMtNDg4My04NDJkLWRlYThhMzEyMTEwZiIsIjk5ZWZkNmIyLTM2MTctNDllYy04MzM3LTIwYTIzMWJiMGZlMSIsImFjMTZlNWIzLTU0N2ItNDJmYS05ZjY4LTdhYWU0NmQ2ZGUzNyIsImFlNzJkY2JhLTlmMjEtNGU1Ni1hMDlhLTNiYzE2NjQ2OTQwYSIsIjkxZWRmNGJiLTdmOTItNDY3Yi04M2M4LTk1NDA2YTZmNWE2ZCIsImE3OGY2OWMyLTY1ZTEtNDIzZS05OWI5LWJlNDVmY2I5ZWU2YSIsImZmYTU0ZGMzLWNhYWEtNGNiZi1hZWUxLTA1NzNjMTJiYjcwMSIsIjlmMWE1N2Q4LTU2MDQtNDZhNC04ZWIxLWZkN2E0NjgwYTA4ZiIsIjIzNmE1OWU1LWQ2NDUtNDVkZi04ZWQwLWMzZDUyNGE5YWIzMCIsIjEzNzY1ZGU1LWQ4ZTgtNDU2Mi1iMjI4LWIwMTExMjNkMWNjMiIsImNkOGI4NWYyLWFjNjYtNGNlNi1hMTJhLWE4ZDkzN2Q4ZTlhMyIsImU4MGUwYmRkLThiZGUtNDE0Yi04NWNiLWE1ZmE5ZGQ0ZDYxMSIsIjM4ZjM5MTRmLTIyNDgtNDY4MS04Y2Q4LTJlNjIxYTRjNWQ0YSIsImIwZDg4ZDA2LTI4Y2UtNDRmNC04NGI3LTA0NDY4ODMwYjU4ZSIsIjgzYTg0ZmQwLWU5ZTUtNDJmNi1hMmJiLWY5MDAzNDE1ZjBhYSIsImNiMzViNTA2LTc3NDMtNGY2Ny1hYTc2LWY3ODQ3OTY3MDgzNyJdLCJpcGFkZHIiOiIxOTkuMjAzLjE0MC4yNSIsIm5hbWUiOiLXkNec15vXodeg15PXqCDXpNec16ZcdTAwMjfXmdem16fXmSAtINee16rXm9eg16oiLCJvaWQiOiI4NzQ5NzNmYy01YTBiLTQxZjMtYWZkZS1kYzNlMzY2YmZkZTAiLCJvbnByZW1fc2lkIjoiUy0xLTUtMjEtOTYxMzAxMzExLTQ5NTYxNDM2NS0xMjI1MjE5MzgxLTExMzkyMiIsInJoIjoiMC5BU1VBRUE5a3F2aVZCVS1XOFZLZHU4RVlseXlndjFOVGxPdFBzQmM1OE1jMi1pRWxBQzQuIiwic2NwIjoiYWNjZXNzX2FzX3VzZXIiLCJzdWIiOiI5bm1wMHMyUW5QQ3V0dTgwcjFzN1ltd2U2RDNiOXpnTzZ3NGtzVTBJOUNNIiwidGlkIjoiYWE2NDBmMTAtOTVmOC00ZjA1LTk2ZjEtNTI5ZGJiYzExODk3IiwidW5pcXVlX25hbWUiOiJjMjE2ODkxMEB0ZWwtYXZpdi5nb3YuaWwiLCJ1cG4iOiJjMjE2ODkxMEB0ZWwtYXZpdi5nb3YuaWwiLCJ1dGkiOiJZS2RkeGxJLWRFS185YUIwcHpSUUJBIiwidmVyIjoiMS4wIiwid2lkcyI6WyJiNzlmYmY0ZC0zZWY5LTQ2ODktODE0My03NmIxOTRlODU1MDkiXX0.h65Cuo1sWNflSvBYxKM_u5LNYNKp68qBsiGnQywxrIhe1UZf2jfjgmMtesyoorXHFEBawUvgfjJkJUFwA_7DB-fjhPT3lxOPbQTaKux190Q8QfVXylqa9uL2ZD-I8b2qRgic_BS9seKpmdcWXBzrU80nnMCZnKZJXROcA05bUshQADGkOZIdpeLl3sxblqgn4tKFPw9SG3SmY97Qd0_v1hlvWM85zeO3g3ejFXJig4tkDQRHXHCURK-idP5htgeAEJ9pTpNCITwkJLqW0SYOTc9ogh9q12DNFIoOH7ZpHwS75e6teEoWZZ_hHQXiLofRK8-gFD1b1ah8UVZLLj5vsA";

        Requests request = new Requests();


        
        public void Ser003()
        {
            int bakashaIdToUpdate = 110;
            int daysBack = 1;

            for (int j = 0; j < daysBack; j++)
            {
                List<string> logs = new List<string>();
                DateTime testDay = WorkDays.CalcWorksDays(accessToken, j);
                logs.Add($"Test Day = {testDay} / Days back = {j}");

                Submission.UpdateSubmissionDate_DB(bakashaIdToUpdate, testDay); // Change submition start day
                var codeParit = RequestItem.GetCodeParit_DB(bakashaIdToUpdate); // Get CodeParit by bakashaId
                var codeStation = StationsDB.Get(codeParit); // Get stations code by codeParit
                StationsDB.UpdateStations_DB(codeStation, testDay);
                Console.WriteLine("codeStation - " + codeStation.Count);

                RestResponse response2 = request.Post(accessToken, "License/ManagerStationsWorkingProcess");
                response2.StatusCode.Should().Be(HttpStatusCode.OK, $"Request failed: api/License/ManagerStationsWorkingProces");
                for (int i = 0; i < codeParit.Count; i++)
                {
                    RestResponse response = request.Get(accessToken, $"license/GetStastionsByItemId?ItemId={codeParit[i]}");
                    response.Should().NotBeNull();
                    response.StatusCode.Should().Be(HttpStatusCode.OK);
                    Console.WriteLine(response);

                    //var bodyContent = JsonSerializer.Deserialize<ApiEntitiesStations>(response.Content);

                    using (JsonDocument document = JsonDocument.Parse(response.Content))
                    {
                        // Перебираем массив объектов в JSON
                        foreach (JsonElement element in document.RootElement.EnumerateArray())
                        {
                            // Извлекаем значения напрямую из JSON
                            int requestItemId = element.GetProperty("requestItemId").GetInt32();
                            string stationName = element.GetProperty("stationName").GetString();
                            string lastStatus = element.GetProperty("lastStatus").GetString();
                            DateTime lastUpdateDate = element.GetProperty("lastUpdateDate").GetDateTime();
                            string email = element.GetProperty("stationType").GetProperty("email").GetString();

                            // Собираем значения в строку и добавляем в список логов
                            string log = $"RequestItemId: {requestItemId}, StationName: {stationName}, LastStatus: {lastStatus}, LastUpdateDate: {lastUpdateDate}, Email: {email}";
                            logs.Add(log);
                        }
                    }


                }
                var messages = MessagesAuditDB.Get();
                var haarraha = HaarachatMoedLemahutDB.Get(codeParit);
                var hatraot = AtraaLetachanaMeasheretDB.Get(codeStation);
                logs.Add($"[ris_t_channel_messages_audit] = {messages}");
                logs.Add($"[ris_t_haarachat_moed_lemahut] = {haarraha}");
                logs.Add($"[ris_t_atraa_letachana_measheret] = {hatraot}");
                SaveLogsToFile.SaveLog(logs);

                //Thread.Sleep(1000);
            }

        }



      
        public void PostBook()
        {
            RestResponse response = request.PostFakeApiRequest();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();

            var bodyContent = JsonSerializer.Deserialize<FakeApiEntities>(response.Content);
            bodyContent.Id.Should().NotBeNull();
            bodyContent.Description.Should().NotBeNull();
            bodyContent.Title.Should().NotBeNull();
            Console.WriteLine($"Excerpt: {bodyContent.PublishDate}");
        }

       
        public void UpdateABook()
        {
            RestResponse response = request.PutFakeApiRequest(15);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();
            var bodyContent = JsonSerializer.Deserialize<FakeApiEntities>(response.Content);
            bodyContent.Id.Should().NotBeNull();
            bodyContent.Id.Should().Be(15);
            bodyContent.Description.Should().NotBeNull();
            bodyContent.Title.Should().NotBeNull();
            System.Console.WriteLine($"Excerpt: {bodyContent.Description}");
        }

        
        public void DeleteABook()
        {
            RestResponse response = request.DeleteFakeApiRequest(15);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();
        }


    }
}

