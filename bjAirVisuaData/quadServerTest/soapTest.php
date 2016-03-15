<?php
/**
 * Created by PhpStorm.
 * User: Administrator
 * Date: 2015/12/7
 * Time: 15:46
 */
ini_set('soap.wsdl_cache_enabled', "0"); //关闭wsdl缓存

$soap = new SoapClient('http://ourgis.digitalearth.cn/QuadServer//ws/admin?wsdl', array('encoding'=>'GBK'));
//$soap = new SoapClient('http://10.2.3.4:8080/QuadServer//ws/admin?wsdl', array('encoding'=>'GBK'));
//var_dump($soap->getVersion());
//var_dump($soap->getServices());
$servicess = $soap->getServices();
//echo $servicess . services[0] . name;
//print_r($servicess);
$array = json_decode(json_encode($servicess),TRUE);
//print_r($array[0]);
echo $array['return'];
$xmlStr=$array['return'];
 $xml = new DOMDocument();
// 读取xml的字符串，变为xml的DomDocument对象
$xml->loadXML($xmlStr);
$tag=$xml->getElementsByTagName('service');
var_dump($tag->item(3)->getElementsByTagName('name')->item(0)->nodeValue);
//$itemArr=$tag->item(2)->getElementsByTagName('name');
//$itemddd=$itemArr.length;
//for(var i=0;i<)
for($i=0;$i<$tag->length;$i++){
    var_dump($tag->item($i)->getElementsByTagName('name')->item(0)->nodeValue);
}




$data = "<?xml version='1.0' encoding='UTF-8' ?>
                <s2m version='1.0'>
                    <body>
                        <orgItem>
                            <userItem>
                                <id>1</id>
                                <userName>梅西</userName>
                                <mobile>1594512369</mobile>
                            </userItem>
                            <userItem>
                                <id>2</id>
                                <userName>哈维</userName>
                                <mobile>13000000000</mobile>
                            </userItem>
                        </orgItem>
                    </body>
                </s2m>";

//$dom=new DomDocument;
//$dom->loadXML($data);
//$tag=$dom->getElementsByTagName('s2m')->item(0)->getElementsByTagName('body')->item(0)->getElementsByTagName('orgItem')->item(0)->getElementsByTagName('userItem');
//$array=array();
//foreach($tag as $key=>$item){
//    $array[$key]['id']=$item->getElementsByTagName('id')->item(0)->nodeValue;
//    $array[$key]['userName']=$item->getElementsByTagName('userName')->item(0)->nodeValue;
//    $array[$key]['mobile']=$item->getElementsByTagName('mobile')->item(0)->nodeValue;
//}
//var_dump($array);