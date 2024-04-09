Feature: HiterNilve_Ser029

באג 18357

בדיקת תקינות - Ser029 עדכון היתר נלווה 
SWAGGER URL : ​​/api​/AdditionalPermit​/CreatePaymentVoucherToAdditionalPermit
השירות מייצר או מעדכן היתר נלווה לפי קלט של סטטוס ומייצר שובר לתשלום אם נדרש
השירות נקרא מתוך שרות 058 עם סטטוס ממתין לאישור אגף רישוי

לבדוק - השירות לא מייצר היתר נלווה אם קיים בתיק העסק היתר נלווה פעיל מאותו סוג, לכן חובה להפעיל שירות זה רק לאחר ביטול ההיתר קיים

אם לא אותרה אף רשומה פעילה  --> יצירת היתר נלווה :scenario <create a new iter nilve>

אם קיימת רשומה שבה סטטוס היתר נלווה = סטטוס בקלט --> מסיים שרות עם הודעה  :scenario <hiter nilve is exists with status = status in the input>
'additional permit status same DB status'

אם קיימת רשומה שבה סטטוס היתר נלווה > סטטוס בקלט --> מסיים שרות עם הודעה :scenario <hiter nilve is exists with status > status in the input>
'the additional permit db status bigger from request status'

אם קיימת רשומה שבה סטטוס היתר נלווה > סטטוס בקלט --> מעדכן סטטוס היתר  :scenario <hiter nilve is exists with status < status in the input>
אם אותרה רשומה פעילה (שאינה עונה על אחד התנאים לעיל) מעדכן ברשומה סטטוס היתר שהתקבל בקלט
אם סטטוס היתר נלווה = ממתין לתשלום מפעיל שירות ser061 חישוב תעריף אגרת היתר נלווה 
אם קוד שגיאה שחזר מהשירות > 1 מחזיר שגיאה [חישוב תעריף אגרה נכשל] ומסיים
אם תעריף אגרת היתר נלווה שחזר מהשירות = 0 אז מעדכן סטטוס היתר נלווה = "הופק" אחרת מפעיל שירות 025 - יצירת שובר
אם קוד שגיאה שחזר מהשירות = 2 אז מחזיר קוד שגיאה [יצירת שובר לתשלום נכשלה] ומסיים  

קיים בטסט - Ser028 יצירת בקשה ותחנות להיתר נלווה

@Test
Scenario Outline: create a new iter nilve
	Given valid access token
	* default tik rishuy with parameters for mahut: 1, 3, 7, 0, 10
	* run Ser028 create additional permit with parameters: <SugIter>, <SibatBakasha>, 10.0, <NumOfAdditionalIters>
	# Note == Ser029 called from Ser058 when tahanot with "Approved" status, status of Hiter - "Awaiting approval" ==
	#* update tahanot of Hiter to status: 3
	* run Ser029 permit update with parameters: <StatusHiterInput>
	Then hiter nilve created in DB: 'Yes'
	Then shovar tashlum for Hiter created in DB: <ShovarCreatedDB>
	Then Ser029 response description should be <ResponseResult>
	Then status of HiterNilve in DB: <StatusHiterOutput>
	Then validate hiter nilve: 1

Examples:
	| SugIter | SibatBakasha | NumOfAdditionalIters | StatusHiterInput | StatusHiterOutput | ShovarCreatedDB | ResponseResult |
	| 1       | 0            | 1                    | 1               | 1                | 'No'            | 'null'         |
	| 1       | 0            | 1                    | 2               | 1                | 'No'            | 'null'         |
	| 2       | 0            | 2                    | 1               | 1                | 'No'            | 'null'         |
	| 3       | 0            | 1                    | 1               | 1                | 'No'            | 'null'         |
	| 7       | 0            | 1                    | 1               | 1                | 'No'            | 'null'         |
	
# default tik rishuy with parameters for mahut: <NumOfMahuyot>, <Maslul>, <MahutRashit>, <DaysBack>

@Test
Scenario Outline: hiter nilve is exists with status equal to status in the input
	Given valid access token
	* default tik rishuy with parameters for mahut: <NumOfMahuyot>, <Maslul>, <MahutRashit>, <DaysBack>, 10.0
	* run Ser028 create additional permit with parameters: <SugIter>, <SibatBakasha>, 1.0, <NumOfAdditionalIters>
	# Note == Ser029 called from Ser058 when tahanot with "Approved" status, status of Hiter - "Awaiting approval" ==
	* run Ser029 permit update with parameters: <StatusHiterInput>
	Then hiter nilve created in DB: 'Yes'

	Given run Ser029 permit update with parameters: <StatusHiterInput>
	Then Ser029 response description should be <ResponseResult>
	Then status of HiterNilve in DB: <StatusHiterInput>
	Then shovar tashlum for Hiter created in DB: <ShovarCreatedDB>


Examples:
	| NumOfMahuyot | Maslul | MahutRashit | SugIter | SibatBakasha | NumOfAdditionalIters | StatusHiterInput | DaysBack | ShovarCreatedDB | ResponseResult                            |
	| 1            | 1      | 9           | 1       | 0            | 1                    | 1               | 0        | 'No'            | 'additional permit status same DB status' |
	| 1            | 1      | 9           | 1       | 0            | 1                    | 3               | 0        | 'No'            | 'additional permit status same DB status' |
	| 1            | 1      | 9           | 1       | 0            | 1                    | 4               | 0        | 'No'            | 'additional permit status same DB status' |
	| 1            | 1      | 9           | 1       | 0            | 1                    | 5               | 0        | 'No'            | 'additional permit status same DB status' |
	| 1            | 1      | 9           | 1       | 0            | 1                    | 6               | 0        | 'No'            | 'additional permit status same DB status' |
	

@Test
Scenario Outline: hiter nilve is exists with status more than status in the input
	Given valid access token
	* default tik rishuy with parameters for mahut: <NumOfMahuyot>, <Maslul>, <MahutRashit>, <DaysBack>, 10
	* run Ser028 create additional permit with parameters: <SugIter>, <SibatBakasha>, 1.0, <NumOfAdditionalIters>
	# Note == Ser029 called from Ser058 when tahanot with "Approved" status, status of Hiter - "Awaiting approval" ==
	* run Ser029 permit update with parameters: 60
	Then hiter nilve created in DB: 'Yes'

	Given run Ser029 permit update with parameters: <StatusHiterInput>
	Then Ser029 response description should be <ResponseResult>
	Then status of HiterNilve in DB: 60
	Then shovar tashlum for Hiter created in DB: <ShovarCreatedDB>

Examples:
	| NumOfMahuyot | Maslul | MahutRashit | SugIter | SibatBakasha | NumOfAdditionalIters | StatusHiterInput | DaysBack | ShovarCreatedDB | ResponseResult                                               |
	| 1            | 1      | 9           | 1       | 0            | 1                    | 1               | 0        | 'No'            | 'the additional permit db status bigger from request status' |
	| 1            | 1      | 9           | 1       | 0            | 1                    | 2               | 0        | 'No'            | 'the additional permit db status bigger from request status' |
	| 1            | 1      | 9           | 1       | 0            | 1                    | 3               | 0        | 'No'            | 'the additional permit db status bigger from request status' |
	| 1            | 1      | 9           | 1       | 0            | 1                    | 4               | 0        | 'No'            | 'the additional permit db status bigger from request status' |
	| 1            | 1      | 9           | 1       | 0            | 1                    | 5              | 0        | 'No'            | 'the additional permit db status bigger from request status' |


@Test
Scenario Outline: hiter nilve is exists with status less than status in the input
	Given valid access token
	* default tik rishuy with parameters for mahut: <NumOfMahuyot>, <Maslul>, <MahutRashit>, <DaysBack>, 10.0
	* run Ser028 create additional permit with parameters: <SugIter>, <SibatBakasha>, 1.0, <NumOfAdditionalIters>
	# Note == Ser029 called from Ser058 when tahanot with "Approved" status, status of Hiter - "Awaiting approval" ==
	* run Ser029 permit update with parameters: 10
	Then hiter nilve created in DB: 'Yes'
	Given update status Hiter to: 10
	Given run Ser029 permit update with parameters: <StatusHiterInput>
	Then Ser029 response description should be <ResponseResult>
	Then status of HiterNilve in DB: <StatusHiterOutput>
	Then shovar tashlum for Hiter created in DB: <ShovarCreatedDB>

Examples:
	| NumOfMahuyot | Maslul | MahutRashit | SugIter | SibatBakasha | NumOfAdditionalIters | StatusHiterInput | StatusHiterOutput | DaysBack | ShovarCreatedDB | ResponseResult |
	| 1            | 1      | 9           | 1       | 0            | 1                    | 3               | 3                | 0        | 'No'            | 'null'         |
	| 1            | 1      | 9           | 1       | 0            | 1                    | 4               | 4                | 0        | 'No'            | 'null'         |
	| 1            | 1      | 9           | 1       | 0            | 1                    | 5               | 5                | 0        | 'No'            | 'null'         |
	| 1            | 1      | 9           | 1       | 0            | 1                    | 6               | 6                | 0        | 'No'            | 'null'         |






@Test
Scenario: temp
	Given valid access token
	* default tik rishuy with parameters for mahut: 1, 3, 7, 0, 10
	#When update the creation date of objects in a loop: '-', 10
	
	* update objects creation date '-00-00-19T00:00', 'essek'
	* run Ser028 create additional permit with parameters: 7, 0, 0.0, 1
	When run Ser066 get business data
	#Given run Ser062 check additional permit possibility with parameters: 1
	Given run Ser029 permit update with parameters: 1
	#Then hiter nilve created in DB: 'No'
	#Then status of HiterNilve in DB: 1
	#Then validate hiter nilve: 0
	#* update tahanot of Hiter to status: 98
	Given update objects creation date '-00-00-05T00:00', 'hiter_nilve'

	#When create draft license with parameters: 7, "2024-02-18T10:00:00.100Z", "2034-02-19T10:00:00.100Z", 2
	#When execute Ser003