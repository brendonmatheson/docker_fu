#!/bin/bash

sudo docker run -d \
	--name registry \
	--restart always \
	-v registry-data:/var/lib/registry \
	-p 5000:5000 \
	registry:2

