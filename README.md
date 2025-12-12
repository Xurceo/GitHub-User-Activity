<div align="center">

# GitHub User Activity CLI

![Version](https://img.shields.io/badge/version-1.0.0-blue)
[![License](https://img.shields.io/badge/license-MIT-green)](https://github.com/USERNAME/REPO/blob/main/LICENSE)
[![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet)](https://dotnet.microsoft.com/download/dotnet/8.0)
[![Linux](https://img.shields.io/badge/target-linux--x64-black?logo=linux)](https://kernel.org)
![No Bugs](https://img.shields.io/badge/bugs-0%20found%20%28allegedly%29-green)

Simple command line interface (CLI) to fetch the recent activity of a GitHub user and display it in the terminal

This project is implementaion of GitHub User Activity CLI idea from [roadmap.sh](https://roadmap.sh/projects/github-user-activity)

</div>

## Installation

### Build from source (With dotnet)

1. Install **git** and the **.NET SDK** for your distribution.

    ```sh
    # Arch Linux
    sudo pacman -S git dotnet-sdk

    # Fedora
    sudo dnf install git dotnet-sdk-8.0

    # Ubuntu / Kubuntu / Debian
    sudo apt update
    sudo apt install git dotnet-sdk-8.0

    # openSUSE
    sudo zypper install git dotnet-sdk-8_0
    ```

2. Clone and install

    ```sh
    git clone https://github.com/Xurceo/GitHub-User-Activity.git
    cd GitHub-User-Activity/github-activity
    sudo chmod +x install.sh && ./install.sh
    ```

## Usage

### Show user activity using ```github-activity <username>``` command

    github-activity kamranahmedse

### Result

    kamranahmedse pushed 11 commits to kamranahmedse/developer-roadmap
    kamranahmedse opened or updated 3 pull requests in kamranahmedse/developer-roadmap
    kamranahmedse created or updated 2 issues in kamranahmedse/developer-roadmap
    kamranahmedse starred typsusan-zzz/canvas-drawing-editor
    kamranahmedse starred logward-dev/logward
    kamranahmedse starred CherryHQ/cherry-studio
    kamranahmedse starred sevlyar/go-daemon
    kamranahmedse starred MohamedH1998/surmiser
    kamranahmedse pushed 1 commit to kamranahmedse/reminder
    kamranahmedse forked 1 repository from highlight/highlight
    kamranahmedse created or updated 3 issues in kamranahmedse/driver.js
    kamranahmedse commented 3 times on issues in kamranahmedse/driver.js
    kamranahmedse opened or updated 1 pull request in kamranahmedse/driver.js

## Support the development

If you like what I do

[![Star Me](https://img.shields.io/badge/Give_me_a_star-⭐-brightgreen)](https://github.com/xurceo/GitHub-User-Activity/stargazers)
![Emotion Support](https://img.shields.io/badge/support-devs_emotional_state-orange)
