<?php
 include('conn.php');
 
/* require the user as the parameter */


	/* soak in the passed variable or set our own */
	
	$searchText = intval($_GET['search']); //no default

	/* grab the Artist from the db */
	
	$query = "select DISTINCT TOP 100  Artist from tblnewsong";
	$result = odbc_exec($con,$query);
	// echo $result;
	/* create one master array of the records */

	while($get_sql_result_row= odbc_fetch_array($result))
	{
			 $json[] = $get_sql_result_row;
			// echo $json;
	}
	/* output in necessary format */
	header('Content-type: application/json');
	echo json_encode($json);


?>