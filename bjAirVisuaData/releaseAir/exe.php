<?php
/**
 * Created by PhpStorm.
 * User: Administrator
 * Date: 2015/11/16
 * Time: 10:21
 */

header('charset: utf-8;');
exec("wcfconsole.exe",$info);


$file=fopen("current_air_pollutant_BJ.js","w+");
$info0="var airData=".$info[0];
//$content="\xEF\xBB\xBF"."var webdata=".$info[0];
$content = iconv('','utf-8',$info0);/*ת��Ϊutf-8����*/
//$infoe='var webdata='.$info[0];

//fputs($file,$infoe);
fwrite($file,$content);
fclose($file);

//将生成的北京市当前的空气污染物数据文件移动到相应的数据文件夹内
rename("current_air_pollutant_BJ.js","../../public/dataset/weather/current/current_air_pollutant_BJ.js");


//$myfile = fopen("jsondata.js", "r") or die("Unable to open file!");
////echo fread($myfile,filesize("jsondata.txt"));
//$infoLast=fread($myfile,filesize("jsondata.txt"));
//$infoLast=trim($infoLast, "\xEF\xBB\xBF");
//fclose($myfile);
//
//var_dump($infoLast);
//$ddd=json_decode($infoLast,true);
//var_dump($ddd);
//$jsonString ="{\"Table\":]}";
//$jsonString ="{Table:]}";
//$jjj=''.$jsonString.'';
//echo ''.$jsonString.'';
////$jsonString=stripslashes($jsonString);
//$jsonString=str_replace('"','$',$jsonString);
//$jsonString=str_replace('$','"',$jsonString);
//echo $jsonString;
//var_dump($jsonString);

//echo strlen($jsonString);
//echo $jsonString;


//echo $info[0];
////$ee=system("wcfconsole.exe",$info);
////echo $ee;
////var_dump($ee);
////print_r($info[0]);
//echo $info[0];
//echo gettype($info[0]);
//var_dump('\"'.$info[1].'\'');
//echo '\n';
//print_r($info[0]);

////var_dump($info);
//$aaa=$info[0];
//echo $aaa;
//$aaa=stripslashes($info[0]);
//$json1=str_replace('$','"',$info[0]);
////$json2=str_replace('$','"',$json1);
//$ddd=json_decode($json1,true);
//var_dump($ddd);
//$ddd=json_decode($info[0],true);
//var_dump(''.$info[0].'');
//echo substr_replace($info[0],'\'',0,1);

//echo $obj->{'Table'};
//echo $info[0];
//echo $info[1];
//echo $info[2];
//echo json_encode($info[0]);