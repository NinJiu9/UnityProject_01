# UnityProject_01
## 获取本项目的代码到你的电脑（以下方法请确保你的账户中保存了你本地仓库的公钥SSH)
创建新的空文件夹，然后在右键菜单中点击 Git Bash Here，输入：  
```git clone git@github.com:NinJiu9/UnityProject_01.git```  

等待项目加载完成  
输入下面代码，如果前面都没有问题，这个时候你应该可以看到自己进入了主分支 main   
`cd UnityProject_01`  

输入下面代码，便创建好分支并进入新建分支了  
`git checkout -b "自定分支名字"`  

对项目做出修改添加删除操作后，输入下面代码可以看出你的项目发生了哪些改动并且尚未保存到git中  
`git status`  

输入下面代码可以将所有的修改都提交到暂存区，确认无误后可以  
`git add .`  

输入下面代码将暂存区所有的修改提交，即保存并记录了本次修改  
`git commit -m"本次提交的备注"`  

上面两步也可以合并为下面代码，可直接将修改一步保存并记录  
`git commit -a -m"本次提交的备注"`   


### 后续使用  
使用下面命令在哪个分支中，便会改变本地仓库或者远程仓库中对应的分支
本地仓库获取github远程仓库的更新  
`git pull`  
  
本地仓库修改更新到github远程仓  
`git push`  

更改分支  
`git checkout master`  

查看本地分支  
`git branch`  

查看远程分支  
`git branch -r`  

查看所有分支  
`git branch -a`  

合并分支master到当前分支  
`git merge master`

### 本地仓库分支更新到远程仓库主分支
先将本地修改commit，更新到远程分支仓库，然后先更换当前分支为主分支，在主分支合并自己的分支， 
```
git add .  
git commit -m"updata"
git push  
git checkout main  
git merge 当前分支名字  
```  
### 远程仓库主分支更新到本地仓库分支
待写。。。。。
