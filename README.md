![License](https://img.shields.io/github/license/ElecRex/HospitalManagementSystem-WPF.svg)
![.net](https://img.shields.io/badge/.NETFramework-4.6.1-blue.svg)

## Overview | 项目概述
- 该系统具备常见医疗流程，并可以完成患者和医生信息的输入，存储，修改，查询，删除等功能。 每个医生都有自己的密码，有人可以更改数据，有人无法修改，只能查看。 同时，数据也有一定的维护，当患者突然生病时，医生可以通过IC卡及时了解患者的病情。 并给予一定的治疗，同时处方药银行也将根据医生的处方开处方，方便患者就医，吃药。
- 默认管理员登陆用户名和密码均为```admin```

若此项目对您有帮助，欢迎star和fork。作者开发不易，可以打赏一下，以便维持生计。
![zanshang](./imgs/appreciation.jpg)


## Installation | 下载安装项目
```bash
$ git clone https://github.com/ElecRex/HospitalManagementSystem-WPF.git
$ cd HospitalManagementSystem-WPF
```

## Requirements

- Visual Studio 2017

- .NET Framework 4.6.1

- SQL Server 2012 / MSSQL LocalDB

## Architecture | 系统架构

```
|__HospitalInfomationManagementSystem
  |
  |__ClassLiberty
  |         |_____Model
  |         |_____DAL
  |         |_____BLL
  |__UI
  |
  |__Database
```
## Database configuration | 数据库路径配置
在```./UI/App.config```配置文件中的```appSettings```，设置已提供的数据库```hospitals.mdf```的连接路径,
默认为相对路径
```XML
<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6.1" />
    </startup>
  <appSettings>
    <add key="strCon" value="server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=|DataDirectory|\hospitals.mdf" />
  </appSettings>
</configuration>
```
## Screenshot | 界面展示及功能简介

### 登陆界面

![LoginUI.png](https://github.com/ElecRex/HospitalManagementSystem-WPF/raw/master/imgs/LoginUI.png)

### 系统管理

![SysManUI.png](./imgs/SysManUI.png)

- 挂号单设置
  
  ![RegDesignUI.png](./imgs/RegDesignUI.png)

- 科室科别添加
  
  ![SecUI.png](./imgs/SecUI.png)

- 科室信息修改
  
  ![SecReviseUI.png](./imgs/SecReviseUI.png)

- 员工添加
  
  ![StaffAddUI.png](./imgs/StaffAddUI.png)

- 权限管理
  
  ![AutManUI.png](./imgs/AutManUI.png)

### 门诊医生

- 选病人
  
  ![ChoosePantientUI.png](./imgs/ChoosePantientUI.png)

- 写病例
  
  ![MediRecUI.png](./imgs/MediRecUI.png)

- 开药
  
  ![DishDrugUI.png](./imgs/DishDrugUI.png)

### 门诊管理

- 病人挂号
  
  ![PatientRegUI.png](./imgs/PatientRegUI.png)

- 医疗卡办理
  
  ![CardRegUI.png](./imgs/CardRegUI.png)

### 门诊收费

![ChargeUI.png](./imgs/ChargeUI.png)

### 住院管理

- 病房查看
  
  ![RoomCheckUI.png](./imgs/RoomCheckUI.png)

- 病房添加
  
  ![BedAddUI.png](./imgs/BedAddUI.png)

- 住院登记
  
  ![RoomRegUI.png](./imgs/RoomRegUI.png)

- 付款查看
  
  ![CashCheckUI.png](./imgs/CashCheckUI.png)

- 病人查找
  
  ![PatientFindUI.png](./imgs/PatientFindUI.png)

- 费用记账
  
  ![FareRegUI.png](./imgs/FareRegUI.png)

- 出院结算
  
  ![DischargSettlementUI.png](./imgs/DischargSettlementUI.png)

### 药房管理

- 查看检药单
  
  ![DrugCheckUI.png](./imgs/DrugCheckUI.png)

- 查看已发药品
  
  ![part6_2.png](./imgs/part6_2.png)

### 药库管理

![DrugstoreUI.png](./imgs/DrugstoreUI.png)

### 财务管理

![FinaManUI.png](./imgs/FinaManUI.png)

## License

- Apache 2.0



