#! /bin/bash

mkdir -p /opt/tsf/app_config/apis 
cp /app/spec.yaml /opt/tsf/app_config/
cp -r /app/apis /opt/tsf/app_config/
cd /app/

dotnet /app/Promotion.dll