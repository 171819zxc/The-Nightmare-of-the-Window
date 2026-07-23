# 恶搞程序-窗口的噩梦

<img width="1920" height="1080" alt="{46E00E0F-0D53-4D44-888A-0733FFA1B46D}" src="https://github.com/user-attachments/assets/cb03be74-3d1d-4fbd-b51a-74349c924be4" />
<img width="1920" height="1080" alt="{F0B16236-ACB5-4DAA-90E4-209C79DEC8CC}" src="https://github.com/user-attachments/assets/501544c6-26d3-4a18-9856-9030405c6478" />
<img width="1920" height="1080" alt="{06303184-471F-4649-BB2D-C124A6DEAF89}" src="https://github.com/user-attachments/assets/82745f42-6188-416c-8184-800203257d9c" />
<img width="1920" height="1080" alt="{6E9573E6-EA0F-4654-A85E-62A80A73D723}" src="https://github.com/user-attachments/assets/f4dae227-40e0-4f20-ae5b-6c397a736799" />
<img width="1920" height="1080" alt="{B7615F28-D87E-4CCD-9015-822398162E00}" src="https://github.com/user-attachments/assets/8011072f-d755-4619-a578-57a9425a1c44" />
<img width="1920" height="1080" alt="{97438662-0B38-4886-B116-A85344421EDC}" src="https://github.com/user-attachments/assets/a004b865-8724-4506-93c5-fc18ad5ad26e" />
<img width="1920" height="1080" alt="{5E903CB5-EE79-44BE-827B-140B6308700D}" src="https://github.com/user-attachments/assets/6d1df503-616a-487b-8e86-d04ff8580ff4" />

## ⚠警告⚠
- 本程序具有危险功能，建议在虚拟机内运行
- 若因运行本程序所造成的一切损失均由运行者承担
- 本程序仅供娱乐与研究，禁止用于破坏计算机
- 破坏计算机均需负法律责任，编写此程序并非出于恶意目的
- 程序具有一定破坏性，若要恶搞朋友，请先在虚拟机内熟悉运行效果
- **程序仅供娱乐玩笑使用，禁止用来破坏他人计算机**
- 若你同意以上协议再执行本程序

## 灵感来源
- Dioxide.exe，https://github.com/Mist0090/Dioxide/
- 同时借用了Suierku的某些的特效

## 环境依赖
- .NET Framework4.7.2
## 运行时的注意事项
- 无论在任何模式下都要在虚拟机内熟悉运行效果，防止意外
- 程序在安全模式下，仅播放噪音与屏幕特效
- 程序在普通模式下加入了随机移动窗口，但是程序分不清哪个窗口是什么属性，所以可能会导致窗口异常比如窗口脱离、超出屏幕范围等
- 程序在危险模式下，严禁使用物理主机运行，在普通模式的基础上，乱点鼠标，乱按键盘，**！不要尝试结束进程！**因为程序使用 `NtSetInformationProcess`将自身设为关键进程

## 运行方法
 1. 以管理员身份运行，程序已经有获取权限的配置
 2. 运行时，窗口置顶显示
 3. 仔细阅读中间的协议，若因运行此程序造成的损失均由运行者承担
 4. 关闭窗口或选择"Exit"则会退出
 5. 未勾选"I have carefully read the above agreement."的情况下，无法运行
 6. "Table Tennis"只是其中的一个payload，默认开启，但开启后可能会有一些卡顿
 7. " View suggestions"作用会显示一个弹窗，内容概述为"在虚拟机内运行，先保存好文件，他会遍历每个窗口进行破坏(不会试图破坏你的隐私)"
 8. "Enable dangerous mode"非常不建议运行，必须在虚拟机内运行，不适合恶搞
 9. "Run in Safe Mode"默认选中，在物理机上建议运行此模式
 10. "Normal mode operation"建议在虚拟机内运行，因为他可能会破坏窗口
 11. 选择"Enable dangerous mode"后则不能再选择安全/危险模式

## 运行效果
- 无论以任何模式运行，均会显示最后的警告，并闪烁提醒
- 运行后如果选择了危险模式，会疯狂让你的鼠标到处乱点、键盘从A-Z乱按，持续修改UTC时间，创建100个回收站，命名方式"Recycle bin" + n个零宽字符 + 回收站的CLSID
- 程序运行完成后，还会判断当前是否为危险模式，如果是还会主动蓝屏"0xC0000005"(即STATUS_ACCESS_VIOLATION)，且设置为系统关键进程
- 非危险模式程序正常退出，最好重启一下

## 其他补充
- 软件界面的文字由第三方软件翻译，有一些可能不标准，请谅解
- 程序没有异常检测，大部分可以正常运行的
- 新手写代码，可能写的不是很好，请原谅
