### Abkürzungen:
 - #f = filesystem
 - #sdc = Stick 
 - #dd= discdump
 - #dd= discdestroyer

____________________________________



```bash
	dnf distro-sync
```
.
```bash
	dnf install wget
```
.
```bash
	mkdir -p /home/y3d/Download
```
.
```bash
	mkdir -p /home/admin/Download
```
.
```bash
	wget https://download.rockylinux.org/pub/rocky/9/isos/x86_64/Rocky-9.4-x86_64-boot.iso ; sha256sum Rocky-9.4-x86_64-boot.iso
```
.


```bash
	lsblk -f /dev/sdc
```
.

- input file outputfile bs= blocksize

```bash
	dd if=/home/admin/Download/Rocky-9.4-x86_64-boot.iso of=/dev/sdc bs=8M status=progress
```
.

- um den localen Platten cache zu leeren und diesen auf den Stick(**sdc**) zu schieben

```bash
	sync 
```

- wir lassen uns den Alias anzeigen

```bash
	cd etc/
```