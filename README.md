# UnityProject_01
## 获取本项目的代码到你的电脑（以下方法请确保你的账户中保存了你本地仓库的公钥SSH)  

创建新的空文件夹，然后在右键Git Bash Here，输入：git clone git@github.com:NinJiu9/UnityProject_01.git 等待加载完成  
输入下面代码，如果前面都没有问题，这个时候你应该可以看到自己进入了主分支 main   
    cd UnityProject_01
输入下面代码，便创建好分支并进入新建分支了  
    git checkout -b "自定分支名字"  
可以对项目做出修改添加删除操作后  
输入下面代码可以看出你的项目发生了哪些改动并且尚未保存到git中  
    git status  
输入下面代码可以将所有的修改都提交到暂存区，确认无误后可以  
    git add .  
输入下面代码将暂存区所有的修改提交，即保存并记录了本次修改  
    git commit -m"本次提交的备注"  
上面两步也可以合并为下面代码，可直接将修改一步保存并记录  
    git commit -a -m"本次提交的备注"  
