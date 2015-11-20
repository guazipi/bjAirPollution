<?php
/**
 * Created by PhpStorm.
 * User: Administrator
 * Date: 2015/11/16
 * Time: 10:21
 */

header('charset: utf-8;');
exec("wcfconsole.exe",$info);


$file=fopen("jsondata.js","w+");
$info0="var webdata=".$info[0];
//$content="\xEF\xBB\xBF"."var webdata=".$info[0];
$content = iconv('','utf-8',$info0);/*转换为utf-8编码*/
//$infoe='var webdata='.$info[0];

//fputs($file,$infoe);
fwrite($file,$content);
fclose($file);


//$f=fopen("../".$file, "wb");
////$text=utf8_encode($ctxtsubmit);
////先用函数utf8_encode将所需写入的数据变成UTF编码格式。
//$text="＼xEF＼xBB＼xBF".$ctxtsubmit;
////"＼xEF＼xBB＼xBF",这串字符不可缺少，生成的文件将成为UTF-8格式，否则依然是ANSI格式。
//fputs($f, $text);
////写入。
//fclose($f);


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