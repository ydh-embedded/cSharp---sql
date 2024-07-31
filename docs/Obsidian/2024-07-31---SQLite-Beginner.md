
#Link https://linuxhint.com/install-use-sqlite-rocky-linux-9/
#NiceToKno DNF : **(Dandified YUM)**
				is the default package manager for 
				redhat RPM-based Linux distributions.
#NiceToKnow crw-rw----  : Zeichenorientierte Geräte (char device)
			   brw-rw---- : Blockorientierte Geräte (block device)

______________
## install

- sudo Rechte anwenden

```bash
	su -
```

.
![[Pasted image 20240731135834.png]]


- Distrobution Update

```bash
	dnf distrosync
```

.
![[Pasted image 20240731135949.png]]

- EPEL Packages - Paketquelle (Repo) installieren 

```bash
	sudo dnf install epel-release
```

.

![[Pasted image 20240731140650.png]]
.
- EPEL Packages anzeigen lassen 

```bash
	ls -lah /etc/yum.repos.d/ | grep epel
```
.

![[Pasted image 20240731141335.png]]


- Bug for Live
![[Pasted image 20240731142237.png]]

.
- da das Paket beschädigt ist entfernen wir es sicherheitshalber mit:

```bash
	sudo dnf remove sqlite
```

- wir entfernen in den HyperV Settings den dynamischen Arbeitsspeicher
- ![[Pasted image 20240731142517.png]]
- danach wir verwenden den Speicherbefehl mit -m  = Megabyte
- Hier sind jetzt 3,2GB freier RAM :-)
- ![[Pasted image 20240731142555.png]]

.
```bash
	sudo dnf install sqlite
```

- Version abrufen

```bash
	sqlite3 --version
```
.
![[Pasted image 20240731143708.png]]

#### Database commands

