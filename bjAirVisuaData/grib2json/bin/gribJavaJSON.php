<?php
/**
 * Created by PhpStorm.
 * User: Administrator
 * Date: 2016/3/15
 * Time: 9:14
 */
$curl = curl_init();
curl_setopt($curl, CURLOPT_URL, 'http://nomads.ncep.noaa.gov/cgi-bin/filter_gfs_0p25.pl?file=gfs.t06z.pgrb2.0p25.f000&lev_10_m_above_ground=on&var_UGRD=on&var_VGRD=on&subregion=&leftlon=0&rightlon=360&toplat=90&bottomlat=-90&dir=%2Fgfs.2016031406');
curl_setopt($curl, CURLOPT_RETURNTRANSFER, 1);
$data = curl_exec($curl);
curl_close($curl);

$file=fopen("currentWind.anl","w+");
// 首先我们要确定文件存在并且可写。
//if (is_writable($filename)) {
fwrite($file,$data);
fclose($file);


//exec("java -version",$out,$status);
//var_dump($out);
//echo $status;

//exec("../grib2json/bin/grib2json -d -n -o temp.json currentWind.anl",$out,$status);
exec("grib2json -d -n -o realTimeWind.json currentWind.anl",$out,$status);
//exec("grib2json -d -n -o temp.json".$data,$out,$status);

//删除中间文件
unlink("currentWind.anl");
//将生成的北京市当前的风速文件移动到相应的数据文件夹内
rename("realTimeWind.json","../../../public/dataset/weather/current/realTimeWind.json");

echo "successfully";