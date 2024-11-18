Feature: Ser007

השירות מכין רשומת הודעה לשליחה במייל/מסרון בכל עת שמתעורר במערכת צורך לשלוח הודעה.

# Ser008 יצירת תחנה מאשרת
# ---שליחת הודעה לתחנה חיצונית על פתיחת התחנה---
# 402203 פרגוד
# 407215 מרכול
# כתובת לשבת יפה - רחוב 414 בית 1
# מהות דורשת משטרה 202400

#@repeat
@Test
Scenario: הכנת_הודעה_באירוע_הפצה_01
	Given valid access token
	* default tik rishuy with parameters for api mahut: 1, 2, 402203, "321689101"
#		Given update objects creation date '-01-02-00T00:00', 'essek'
#	When create license in DB: 4, 2, 3,  "2023-02-06T10:00:00.100Z", "2033-01-13T10:00:00.100Z"
#	When create draft license with parameters: 7, "2024-10-20T10:00:00.100Z", "2034-04-29T10:00:00.100Z", 3

	Given update objects creation date '-00-00-21T00:00', 'essek'
#	Given run Ser028 create additional permit with parameters: 2, 0, 100, 1
#
#	Given run Ser029 permit update with parameters: 4


#	Then Ser029 response description should be 'null'
#	Given update objects creation date '-00-11-25T00:00', 'hiter_nilve'


#
#
#	Given run Ser062 check additional permit possibility with parameters: 2
#		When run Ser066 get business data
 

	  #Examples:
   # | repeat |
   # | 1      |
   # | 2      |




# Ser029 עדכון היתר נלווה   
# אם סטטוס ההיתר "הופק" מפעיל שירות 007 הכנת הודעה להפצה 

@Test
Scenario: הכנת_הודעה_באירוע_הפצה_02
	Given valid access token
	* default tik rishuy with parameters for mahut: 1, 2, 407200, 0, 122
	* run Ser028 create additional permit with parameters: 1, 0, 0.0, 1
	* run Ser029 permit update with parameters: 10
	Then Ser029 response description should be 'null'
	Then status of HiterNilve in DB: 10
	#Then validate hiter nilve: 0

	When run ischur hiter nilve 4 times


# S012 אישור רישיון  
# ליצור רישיון ממתין לאישור
# מפעיל שירות 007 הכנת הודעה להפצה לאחר אישור רישיון שממתין לאישור 

@Test
Scenario: הכנת_הודעה_באירוע_הפצה_03
	Given valid access token
	* default tik rishuy
	When create license in DB: 2, 8, 3,  "2024-02-06T10:00:00.100Z", "2033-01-13T10:00:00.100Z"