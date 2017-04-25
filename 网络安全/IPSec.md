## 安全通信
### SA 安全关联
安全关联是指互联网安全通信协议(IPsec)中接收者收集的有关安全方案细节的摘要。
* a one-way relationship between sender & receiver that affords security for traffic flow
* has a number of other parameters
* seq no, AH & EH info, lifetime etc
* have a database of Security Associations
#### defined by 3 parameters:
* Security Parameters Index (SPI)
* IP Destination Address
* Security Protocol Identifier
#### SA的管理
##### 创建
* 先协商SA参数，再更新SDAB； 
* 可通过人工创建，也可采用动态创建方式。 
##### 删除 
* 有效期过期：超出时间或使用SA的字节数已超过策略设定的值；
* 密钥已遭破坏；
* 另一端要求删除这个SA。 
### AH 验证头
IPsec 认证头协议（IPsec AH）是 IPsec 体系结构中的一种主要协议，它为 IP 数据报提供无连接完整性与数据源认证，并提供保护以避免重播情况。一旦建立安全连接，接收方就可能会选择后一种服务。AH 尽可能为 IP 头和上层协议数据提供足够多的认证。
* provides support for data integrity & authentication of IP packets
* end system/router can authenticate user/app
* prevents address spoofing attacks by tracking sequence numbers
* The limited ability of against replay attack
* based on use of a MAC
* parties must share a secret key
### 抗重播服务
#### 序列号字段
创建一个新的SA时，发送者会将序列号计数器初始化为0； 
每当在这一SA上发送一个数据包，序列号计数器的值就加1并将序列号字段设置成计数器的值； 
当达到其最大值232-1时，就应建立一个新的SA。 
#### 一种”滑动”窗口机制
IP是无连接的、不可靠的 ，需设立窗口；
窗口的最左端对应于窗口起始位置的数据包序列号N，则最右端对应于可以接收的合法分组的最高序号N+W-1。 
