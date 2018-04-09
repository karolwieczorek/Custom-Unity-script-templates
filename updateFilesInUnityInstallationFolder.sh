#!/bin/bash

if [[ $EUID -ne 0 ]]; then
   echo "This script must be run as root" 1>&2
   exit 1
fi

cp ./* "/Applications/Unity/Unity.app/Contents/Resources/ScriptTemplates/"
chown -R root:wheel "/Applications/Unity/Unity.app/Contents/Resources/ScriptTemplates/"
