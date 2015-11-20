<?php
/**
 * Created by PhpStorm.
 * User: Administrator
 * Date: 2015/11/17
 * Time: 3:11
 */
include 'webdata.php';
header('charset: utf-8;');
exec("wcfconsole.exe",$info);


$file=fopen("webdata.php","w+");
$info0='$webdata='.$info[0];
//$content="\xEF\xBB\xBF"."var webdata=".$info[0];
$content=$info0;
//$content = iconv('','utf-8',$info0);/*×ª»»Îªutf-8±àÂë*/
//$infoe='var webdata='.$info[0];

//fputs($file,$infoe);
fwrite($file,$content);
fclose($file);


$ddd=json_decode($webdata,true);

var_dump($ddd);
//echo $webdata->Table[0].Station;



