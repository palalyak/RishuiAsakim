Feature: HiterNilve_Ser28_positive

Ser028 יצירת בקשה ותחנות להיתר נלווה
/LicenseService/api/AdditionalPermit/CreateAdditionalPermitRequest
תנאיים: תיק עסק > בקשה > מהות > תחנות

באג 17848
באג 18350

לבדוק באיזה סטטוס בקשה נפתחת!!
לבדוק שאם בקשה להיתר היא חידוש ולהיתר יש חידוש אוטומטי, אף תחנה לא נפתחת!!!

Scenario <create bakasha and tahanot for iter nilve>
בדיקה: אם {סיבת בקשה להיתר נלווה} מהקלט =! חידוש וגם {האם חידוש אוטומטי} =! 1 מסוגי היתר נלווה
אז שרות 28 מייצר בקשה (מסך היתרים נלווים לטיפול) ותחנות בתיק עסק 

0. NumOfAdditionalIters = 2, NumOfMahuyot = 2, SibatBakasha = לא חידוש, SugIter = חידוש אוטומטי) לילה — sug_cheadush)
1. NumOfMahuyot = 1, SibatBakasha = לא חידוש, SugIter = חידוש אוטומטי) לילה — sug_cheadush)
2. NumOfMahuyot = 1, SibatBakasha = לא חידוש, SugIter = חידוש אוטומטי) שולחנות — sug_cheadush)
3. NumOfMahuyot = 1, SibatBakasha = לא חידוש, SugIter = חידוש) פרגוד — sug_cheadush)
4. NumOfMahuyot = 1, SibatBakasha = לא חידוש, SugIter = חידוש אוטומטי) שבת יפו — sug_cheadush)
5. NumOfMahuyot = 1, SibatBakasha = לא חידוש, SugIter = אין חידוש) מרכול — sug_cheadush)
6. NumOfMahuyot = 1, SibatBakasha = לא חידוש, SugIter = אין חידוש) דוכן — sug_cheadush)

7. NumOfMahuyot = 1, SibatBakasha = חידוש היתר לילה, SugIter = חידוש) פרגוד — sug_cheadush)
8. NumOfMahuyot = 1, SibatBakasha = חידוש היתר שולחנות וכסאות, SugIter = אין חידוש) מרכול — sug_cheadush)
9. NumOfMahuyot = 1, SibatBakasha = חידוש היתר פרגוד, SugIter = אין חידוש) דוכן — sug_cheadush)
10. NumOfMahuyot = 1, SibatBakasha = חידוש היתר שבת, SugIter = חידוש) פרגוד — sug_cheadush)
11. NumOfMahuyot = 1, SibatBakasha = חידוש היתר נלווה, SugIter = אין חידוש) מרכול — sug_cheadush)

Scenario <tahanot for iter nilve are not opened, bakasha only>
בדיקה: אם {סיבת בקשה להיתר נלווה} מהקלט = חידוש וגם {האם חידוש אוטומטי} = 1 מסוגי היתר נלווה
מחזיר קוד שגיאה 1 ואת הפלט ומסיים

@Test
Scenario Outline: create bakasha and tahanot for iter nilve
	Given valid access token
	* default tik rishuy
	Given run Ser028 create additional permit with parameters: <SugIter>, 0, 25.0, <NumOfHiters>
	Then hiter nilve created in DB: 'No'
	Then status of tahanot for HiterNilve in DB: 1, <NumOfHiterTahana>
	Then bakasha laTipul tahanot: true, 0
	#Given update objects creation date '-00-11-00T00:00', 'essek'

	# Then  [ris_t_bakasha_lheiter_nilve] מקבלים רשומה ב
	# Then  [ris_t_tachana_measheret] מקבלים רשומה ב
	# Then   מקבלים תחנות בטאב תחנות להיתר - לא פותח
	# Then   מקבלים בקשה בטאב בקשות להיתר - לא פותח
	# Then   מקבלים רשומה במסך היתרים נלווים לטיפול


Examples:
	| SugIter | NumOfHiters | NumOfHiterTahana |
	| 1       | 1           | 1                |
	| 2       | 1           | 1                |
	| 3       | 1           | 1                |
	| 7       | 1           | 1                |
	| 8       | 1           | 1                |



@Test
Scenario Outline: tahanot for iter nilve are not opened
	Given valid access token
	* default tik rishuy
	Given run Ser028 create additional permit with parameters: <SugIter>, <SibatBakasha>, 0.0, <NumOfHters>
	Then status of tahanot for HiterNilve in DB: 1, <NumOfHiterTahana>
	Then hiter nilve created in DB: 'No'

Examples:
	| SugIter | SibatBakasha | NumOfHters | NumOfHiterTahana |
	| 1       | 45           | 1          | 0                |

# -- תיק עסק -- [ris_t_essek]
# <StateEssek>: true - תיק עסק מוקפא

# --סוגי היתר נלווה -- [ris_tt_sug_heiter_nilve]
# Code  sug_cheadush  him_nidrash_tashlum_hagra  him_taloi_berishaion tkufat_hiter_min tkufat_hiter_max mispar_chodashiom_lechidush teur
#	1		1			1							0					3				12				לילה	
#	2		1			1							1					שולחנות              12               3		
#	3		2			1							1					פרגוד               7               7
#	4		1			0							0					שבת יפו              12               3
#	5		0			0							1					מרכול              24               3
#	6		0			0							NULL				דוכן

# sug_cheadush : 
# 0 – אין חידוש
# 1 – חידוש אוטומטי
# 2 – חידוש

# -- סיבה לבקשה -- [ris_tt_sibot_bakasha] <SibatBakasha>
# 0 - שום סיבה, לטסט
# 1	שינוי מהות
# 3	הוספת שטח
# 4	הפחתת שטח
# 5	החלפת בעלים
# 6	תוספת שותף
# 7	יציאת שותף
# 8	שינוי שם
# 9	הוספת פריט
# 10 ביטול פריט
# 11 עסק חדש
# 31 שינויים פנימיים
# 32	הוספת בעלים מסוג חברה
# 43	עדכון מנהלים בחברה
# 13	חידוש רישיון
# 27	אירוע חד פעמי
# 29	רוכלות
# 30	חידוש שימוש חורג
# 14	היתר לילה
# 15	היתר שולחנות
# 16	היתר פרגוד
# 17	היתר דוכן/מתקן
# 18	היתר חניון
# 19	היתר חד-פעמי
# 21	היתר שבת
# 35	חידוש היתר לילה
# 36	חידוש היתר שולחנות וכסאות
# 37	חידוש היתר פרגוד
# 40	חידוש היתר שבת
# 44	היתר לפתיחת מרכול בשבת
# 45	חידוש היתר נלווה

# <StatusBakasha>: [ris_tt_status_bakasha]  
# 1 - נשלחה
# 2 - אושרה
# 3 - סיום טיפול
# 4 - בטיפול

# -- mahut -- [ris_tt_sug_mahut]
# Code	teur
# 0 will be created randomly
# 1	מסעדה
# 2	בריכה
# 3	חדר כושר
# 4	חדר אוכל
# 5	ז'קוזי
# 6	בר
# 7	בית אוכל
# 8	קיוסק
# 9	בית מלון
# 104102	מניקור
# 104200	מספרה
# 402200	מזנון,בית אוכל אחר ,לרבות הגשת משקאות משכרים לצריכה במקום, ושאינו עסק שעיקר פעילותו הגשת משקאות משכרים לצורך צריכה במקום ההגשה כאמור בפריט 4.8
# 407200	מרכול - מקום לממכר מזון ומוצרי צריכה לשימוש אישי או ביתי, שאין בו טיפול במזון לרבות משלוח מזון


# -- סטטוס היתר -- [ris_tt_status_heiter_zmani] -- StatusIter --
# Code	teur
# 10	ממתין לאישור אגף רישוי
# 20	ממתין לתשלום
# 30	ממתין להפקה
# 40	הופק
# 50	סורב
# 60	נדחה