![[Pasted image 20240730142620.png]]

#link https://rockylinux.org/de
#Link https://phoenixnap.com/kb/upgrade-rocky-linux-8-to-9

___________________________
### install Rocky
#### download iso file
- File from [Origin](https://rockylinux.org/de/download) 
	- ![[Pasted image 20240730132509.png]]
- Wir installieren Roxk in der VM (hyperV)
	- ![[Pasted image 20240730133930.png]]
	- ![[Pasted image 20240730133855.png]]
- Wir geben der Machine 2 Kerne und 4096 MB in den Einstellungen der VM
	- ![[Pasted image 20240730134118.png]]
- WICHTIG: Wir entfernen das Häkchen [  ]  "sicheren Start aktivieren"
- 
	- ![[Pasted image 20240730134233.png]]
	- 
	- ![[Pasted image 20240730134435.png]]
	- ![[Pasted image 20240730134500.png]]
	- ![[Pasted image 20240730134534.png]]
	- ![[Pasted image 20240730134653.png]]
- wir legen Root-Passwort und einen neuen Benutzer an:
	- bei kurzen Passwörtern muss mann zum übernehmen doppelt auf Fertig klicken
	- Den Benutzer und Passwort notieren 
- wir aktivieren die Internet-Schnittstelle:
	- ![[Pasted image 20240730135916.png]]
- Um die Installationsquelle zu finden benötigen wir die korrekte [URL](https://download.rockylinux.org/pub/rocky/)
	- https://download.rockylinux.org/pub/rocky/8/BaseOS/x86_64/os/
		- oder
	- https://download.rockylinux.org/pub/rocky/9/BaseOS/x86_64/os/
	- ![[Pasted image 20240730135440.png]]
	- ![[Pasted image 20240730135956.png]]
	- ![[Pasted image 20240730140024.png]]
	- ![[Pasted image 20240730141231.png]]
	- ![[Pasted image 20240730141301.png]]
	- ![[Pasted image 20240730141406.png]]
	- 

```bash
	reboot
```
.

### UpGrade Rocky 
- from 8.10 to 9.40

#### Step 1: Check OS Version

Check the current [OS](https://phoenixnap.com/glossary/operating-system) version to ensure you are running Rocky Linux 8. Run the following command:

```bash
	cat /etc/os-release
```
.
		![[Pasted image 20240730125031.png]]
- Hier die Version 8.8
#### Step 2: Update Package Repository

The next step is to update the system package [repository](https://phoenixnap.com/glossary/what-is-a-repository) and upgrade all the packages to their latest versions.

Run the following command:

```bash
	sudo dnf upgrade --refresh
```
.

		![[Pasted image 20240730125219.png]]

#### Step 3: (Optional) Backup the System

If you have important data on the machine, [create a backup](https://phoenixnap.com/blog/backup-strategy) before proceeding. Although it should be safe, it is generally a good idea to back up your important files and system configurations.

You can use software that takes a [snapshot](https://phoenixnap.com/kb/snapshot-vs-backup) of your whole OS or use the following command to back up the files manually:

```bash
	sudo tar czf /rocky8.tar.gz \
     --exclude=/rocky8.tar.gz \
     --exclude=/dev \
     --exclude=/mnt \
     --exclude=/proc \
     --exclude=/sys \
     --exclude=/run \
     --exclude=/tmp \
     --exclude=/media \
     --exclude=/lost+found \
     /
```
.

#### Step 4: Add Rocky Linux 9 Repositories

In this step, export several packages (**`rocky-release`**, **`rocky-repos`**, and **`rocky-gpg-keys`**) as environment variables, which are required for the upgrade. Then, pass the variables to the **`dnf`** [package manager](https://phoenixnap.com/glossary/what-is-a-package-manager) to install the latest package versions.

Check the latest versions on the [official Rocky Linux website](http://download.rockylinux.org/pub/rocky/9/BaseOS/x86_64/os/Packages/r/):

		![[Pasted image 20240730125618.png]]


##### Add Temp File step by step 
```bash
export REPO_URL="https://download.rockylinux.org/pub/rocky/9/BaseOS/x86_64/os/Packages/r"

```
.

```bash
	export RELEASE_PKG="rocky-gpg-keys-9.4-1.7.el9.noarch.rpm"
```
.

```bash
	export REPOS_PKG="rocky-repos-9.4-1.7.el9.noarch.rpm"
```
.

```bash
	export GPG_KEYS_PKG="rocky-gpg-keys-9.4-1.7.el9.noarch.rpm"
```
.
- After [setting the variables](https://phoenixnap.com/kb/linux-set-environment-variable), add the repositories by running:

```bash
	sudo dnf install --nobest $REPO_URL/$RELEASE_PKG $REPO_URL/$REPOS_PKG $REPO_URL/$GPG_KEYS_PKG
```
. oder wenn wir eine Fehlermeldung bekommen: 

##### ReAdd Temp File step by step 
.

```bash
	sudo dnf clean all
```
.

```bash
export REPO_URL="https://download.rockylinux.org/pub/rocky/9/BaseOS/x86_64/os/Packages/r"

```
.

```bash
	export RELEASE_PKG="rocky-gpg-keys-9.4-1.7.el9.noarch.rpm"
```
.

```bash
	export REPOS_PKG="rocky-repos-9.4-1.7.el9.noarch.rpm"
```
.

```bash
	export GPG_KEYS_PKG="rocky-gpg-keys-9.4-1.7.el9.noarch.rpm"
```
.
```bash
	sudo dnf install --skip-broken $REPO_URL/$RELEASE_PKG $REPO_URL/$REPOS_PKG $REPO_URL/$GPG_KEYS_PKG
```
.
		![[Pasted image 20240730124844.png]]

- wir lassen uns den Wert der Systemvariable anzeigen:

```bash
	echo $REPO_URL 
```
.
		- ![[Pasted image 20240730131520.png]]
