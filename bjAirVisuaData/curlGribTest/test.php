<?php
/**
 * Created by PhpStorm.
 * User: Administrator
 * Date: 2016/3/14
 * Time: 15:32
 */
// 初始化一个 cURL 对象
$curl = curl_init();

// 设置你需要抓取的URL
//curl_setopt($curl, CURLOPT_URL, 'http://nomads.ncep.noaa.gov/cgi-bin/filter_gfs.pl?file=gfs.t00z.pgrb2.1p00.f000&lev_10_m_above_ground=on&var_UGRD=on&var_VGRD=on&dir=%2Fgfs.${20140101}00" -o gfs.t00z.pgrb2.1p00.f000');
//curl_setopt($curl, CURLOPT_URL, 'http://nomads.ncep.noaa.gov/cgi-bin/filter_gfs.pl?file=gfs.t00z.pgrb2.1p00.f000&lev_10_m_above_ground=on&var_UGRD=on&var_VGRD=on&dir=%2Fgfs.2014010100');

//curl_setopt($curl, CURLOPT_URL, 'http://nomads.ncep.noaa.gov/cgi-bin/filter_gfs_0p25.pl?file=gfs.t06z.pgrb2.0p25.f000&lev_2_m_above_ground=on&var_UGRD=on&var_VGRD=on&leftlon=0&rightlon=360&toplat=90&bottomlat=-90&dir=%2Fgfs.2016031400');
curl_setopt($curl, CURLOPT_URL, 'http://nomads.ncep.noaa.gov/cgi-bin/filter_gfs_0p25.pl?file=gfs.t06z.pgrb2.0p25.f000&lev_10_m_above_ground=on&var_UGRD=on&var_VGRD=on&subregion=&leftlon=0&rightlon=360&toplat=90&bottomlat=-90&dir=%2Fgfs.2016031406');
// 设置header
//curl_setopt($curl, CURLOPT_HEADER, 1);

// 设置cURL 参数，要求结果保存到字符串中还是输出到屏幕上。
curl_setopt($curl, CURLOPT_RETURNTRANSFER, 1);


//$data = $GLOBALS['HTTP_RAW_POST_DATA'];
// 运行cURL，请求网页
$data = curl_exec($curl);

// 关闭URL请求
curl_close($curl);

// 显示获得的数据
//var_dump($data);
//
$file=fopen("currentWind.anl","w+");
// 首先我们要确定文件存在并且可写。
//if (is_writable($filename)) {
fwrite($file,$data);
fclose($file);
echo("dk");