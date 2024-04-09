Feature: CreateEssecDB

Create custom tik essek


@Test
Scenario Outline: create essek in DB
	Given valid access token
	* default tik rishuy with parameters for mahut: 1, 3, 10, 18, 10
	When bakasha with parameters: <KodStatusBakasha>,  <DaysBack>
	* <NumOfMahuyot> mahuyot lebakasha with parameters: <KodMaslul>, <KodMahutRashit>
	* tahananot meashrot for all mahuyot with parameter: <DaysBack>
	* 1 set of all types of Baaley Inyan
	When cancel the bakasha "NO"


Examples:
	| KodStateEssek | KodStatusBakasha | DaysBack | NumOfMahuyot | KodMaslul | KodMahutRashit |
	| false         | 1                | 0        | 1            | 1         | 1              |
	| false         | 2                | 0        | 1            | 2         | 2              |
	| false         | 3                | 0        | 1            | 3         | 3              |
	| false         | 4                | 0        | 1            | 4         | 4              |

	| false         | 1                | 0        | 2            | 1         | 1              |
	| false         | 2                | 0        | 2            | 2         | 2              |
	| false         | 3                | 0        | 2            | 3         | 3              |
	| false         | 4                | 0        | 2            | 4         | 4              |
	| true          | 1                | 0        | 2            | 1         | 0              |



@Test
Scenario Outline: לשנות_תאריך_ייצור_לפי_ימי_עבודה
	#Given valid access token
	* default tik rishuy with parameters for mahut: 1, 3, 10, 10, 10
	#When update the creation date of objects in a loop: '+', 15

@Test
Scenario Outline: להריץ_שירות_003
	Given valid access token
	When execute Ser003

# -- תיק עסק -- [ris_t_essek]
# <KodStateEssek>: true - תיק עסק מוקפא

# -- מהות -- [ris_tt_sug_mahut] <KodMahutRashit>
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



#  -- בקשה -- [ris_t_bakasha]
# k_siba_i_bchirat_essek_kodem
# השדה רלוונטי רק כאשר מגישים בקשה על עסק חדש
# במקרה זה המקוונת מציגה למגיש את רשימת העסקים הקיימים בכתובת בה הוא רוצה להקים את העסק שלו
# המגיש יכול לבחור את אחד העסקים מהרשימה (אם הוא יודע שהוא מחליף את העסק הנבחר) או לבחור סיבה לאי בחירת עסק קודם.
# <KodStateBakasha>: true - מבוטלת
# sug_bakasha_rishaion_heiter

# <KodStatusBakasha>: [ris_tt_status_bakasha]  
# 1 - נשלחה
# 2 - אושרה
# 3 - סיום טיפול
# 4 - בטיפול

# [ris_tt_sibot_bakasha]
# 1- בעלים
# 9 - הוספת פריט
# 13 - חידוש רישיון

# [ris_tt_sug_bakasha]
# 1 - עסק חדש
# 2 - שינוי מהות

# [ris_tt_maslul_rishayon]
# 1 - מסלול תצהיר
# מסלול היתר מזורז א - 2   
# 3 - מסלול היתר מזורז ב
# מסלול רגיל - 4 

# [ris_tt_status_mahut]
# Code	teur
# 1	נשלחה
# 2	בטיפול
# 3	אושר

# [ris_tt_status_tachana_measheret]
# 1	נשלח
# 2	טיפול
# 3	אישור
# 4	סירוב
# 5	תנאי מוקדם
# 8	לידיעה
# 11 היתר זמני
# 12 תזכורת
# 13 חידוש היתר
# 17 נדחה על ידי הפיקוח
# 18 אושר על ידי הפיקוח
# 19 בבדיקת גורם הפיקוח
# 20 אושרה בקשת מרכול לשבת
# 21 אושר היתר מזורז א
# 22 אושר היתר מזורז ב
# 23 אושר היתר מזורז א הארכה
# 24 אושר היתר מזורז ב הארכה
# 25 אושר אוטומטית
# 26 היתר זמני אוטומטית
# 27 אושר תצהיר
# 28 נדחה
# 98 בטיפול של בעל עסק
# 99 נדחה אוטומטית

# [ris_tt_sug_tachana_measheret]
# Code	teur	sw_chizoni
# 1	הנדסה לעסקים	0
# 2	בקורת עסקים	0
# 3משטרה  	1
# 4	רשות כבאות והצלה	1
# 5	הרשות לאיכות הסביבה	0
# 6	אגף התנועה	0
# 7	מבנים מסוכנים	0
# 8	משרד העבודה והרווחה	1
# 9	משרד התחבורה	1
# 10 משרד הבריאות	1
# 11 משרד להגנת הסביבה	1
# 12 רשות הרישוי	0
# 13המחלקה המשפטית 	0
# 14 אגף דרכים ומאור	0
# 15 תכנון הנדסי	0
# 16 ועדה מקומית	0
# 21 וטרינר	0
# 22 אגף הפיקוח	0
# 23 מה"ב - התקנת מז"ח	1
# 26 מבנה לשימור	0
# 27מינהל הספורט 	0
# 28 משרד הביטחון	1
# 29 מחלקת ביוב	1
# 32 אגף הנכסים	0
# 35 אגף התברואה	0
# 37 היטל השבחה	0
# 38 משרד החינוך קייטנות	1
# 41 הצהרת מהנדס	0
# 47 אגרת ש. חורג	0
# 49 מהנדס בטיחות	0
# 52 מנהלת הגז	1
# 58 תאגיד המים	1
# 59 היתר לשימוש חורג	0
# 60 מורשה נגישות	0
# 61 נגישות ביקורת	0
# 62 אגף החופים	0
# 66 הג"א מקלוט	1
# 69 כיבוי אש - תצהיר	0
# 99 אחוזת החוף	1
# 150 רישוי הנדסי	0
# 151 פיקוח עירוני	0