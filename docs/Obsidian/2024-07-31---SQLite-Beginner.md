
#Link https://linuxhint.com/install-use-sqlite-rocky-linux-9/
#NiceToKno DNF : **(Dandified YUM)**
				is the default package manager for 
				redhat RPM-based Linux distributions.

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

- EPEL Packages

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


