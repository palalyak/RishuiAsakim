Feature: HiterNilve_Ser030

A short summary of the feature

# חידוש_היתר_לילה
# תקופה היתר מבוקש == תקופת היתר מקסימלית וחידוש הוא חודש לפני תאריך התפוגה = חידוש מוצלח
# תקופה היתר מבוקש == תקופת היתר מינימלית וחידוש הוא חודש לפני תאריך התפוגה = חידוש מוצלח
# תקופה היתר מבוקש == תקופת היתר מקסימלית וחידוש הוא חודשיים לפני תאריך התפוגה = חידוש מוצלח
# תקופה היתר מבוקש == תקופת היתר מינימלית וחידוש הוא חודשיים לפני תאריך התפוגה = חידוש מוצלח

@Test
Scenario Outline: חידוש_היתר_לילה
	Given valid access token
	* default tik rishuy with parameters for mahut: 1, 2, <kodMahutRashit>, 0, 10
	#Given tik rishuy for GIS: 7, alef, לא כללית, true, 2, true
	* update objects creation date '-03-00-00T00:00', 'essek'
	When create draft license with parameters: 7, "2022-02-18T10:00:00.100Z", "2034-02-19T10:00:00.100Z", 2

	Then validate hiter nilve: 0
	Given run Ser028 create additional permit with parameters: <SugIter>, 0, 0, 1
	# Note == Ser029 called from Ser058 when tahanot with "Approved" status, status of Hiter - "Awaiting approval" ==
	* run Ser029 permit update with parameters: 4
	#Then Ser029 response description should be 'null'
	Then hiter nilve created in DB: 'Yes'
	Then validate hiter nilve: 1

	Given update objects creation date <hodashimLifneiHidush>, 'hiter_nilve'
	Given run Ser062 check additional permit possibility with parameters: <SugIter>
	When run Ser030 renew additional permit <requestEndHour>, <tkufatHiter>, 0
	When run Ser066 get business data
	Then validate hiter nilve: 2
	#Then אם קיים תעריף להיתר שבקשנו לחדש אז נוצר היתר בסטטוס 20


Examples:
	| kodMahutRashit | SugIter | requestEndHour | hodashimLifneiHidush | tkufatHiter       |
	| 5             | 2       | '23:55'        | '-01-11-00T00:00'    | '+01-00-00T00:00' |
	| 10             | 7       | '23:00'        | '-00-11-00T00:00'   | '+00-03-00T00:00' |

	| 10             | 1       | '23:00'        | '-00-11-29T00:00'    | '+00-12-00T00:00' | 
	| 10             | 1       | '23:00'        | '-00-11-29T00:00'    | '+00-03-00T00:00' |

	| 10             | 1       | '23:00'        | '-00-12-29T00:00'    | '+00-12-00T00:00' |
	| 10             | 1       | '23:00'        | '-00-12-29T00:00'    | '+00-03-00T00:00' |

	| 10             | 1       | '23:00'        | '-00-12-00T00:00'    | '+00-12-00T00:00' |
	| 10             | 1       | '23:00'        | '-00-12-00T00:00'    | '+00-03-00T00:00' | 
	| 10             | 1       | '23:00'        | '-01-01-00T00:00'    | '+00-03-00T00:00' | 



# teur								לילה	שולחנות וכסאות			   פרגוד 	
# sug_cheadush						1			1						2	
# him_nidrash_tashlum_hagra			1			1						1	
# him_taloi_berishaion				0			1						1	
# tarich_tchilat_hiter				NULL		NULL				2024-10-01	
# tarich_siom_hiter					NULL		NULL				2025-04-30	
# tkufat_hiter_min					3			3						7	
# tkufat_hiter_max					12			12						7	
# mispar_chodashiom_lechidush		2			2						NULL	
# fk_sug_avodot_tashtit				3			NULL					NULL	
# fk_code_tlut_sug_heiter_nilve		NULL		NULL					2	
# IsActive							1			1						1	
# fk_kvuzat_maut					NULL		4.2a/4.2b/4.2g/4.2  	4.2/4.8			
# tarich_siom_onat_hiter			NULL		NULL					00:00.0	
# tarich_tchilat_onat_hiter	NULL	NULL		00:00.0					NULL	

# sug_cheadush : 
# 0 – אין חידוש
# 1 – חידוש אוטומטי
# 2 – חידוש

# -- סטטוס היתר -- [ris_tt_status_heiter_zmani] -- StatusIter --
# Code	teur
# 10	ממתין לאישור אגף רישוי
# 20	ממתין לתשלום
# 30	ממתין להפקה
# 40	הופק
# 50	סורב
# 60	נדחה
