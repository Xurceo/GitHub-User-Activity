#!/bin/sh
set -e

# Path to project folder relative to this script
PROJECT_DIR="./github-activity"

# Publish a standalone Linux executable
echo "Publishing standalone executable..."
dotnet publish "$PROJECT_DIR" -c Release -r linux-x64 --self-contained true

PUBLISH_DIR="$PROJECT_DIR/bin/Release/net8.0/linux-x64/publish"
INSTALL_DIR="$HOME/.local/bin/github-activity-files"

# Ask user if they want to install
read -p "Install as command 'github-activity' to ~/.local/bin? [y/N]: " answer
if [[ "$answer" =~ ^[Yy]$ ]]; then
    echo "Installing..."

    # Create install directory
    mkdir -p "$INSTALL_DIR"

    # Copy all published files
    cp -r "$PUBLISH_DIR/"* "$INSTALL_DIR/"
    chmod +x "$INSTALL_DIR/github-activity"
    ln -s "$INSTALL_DIR/github-activity" ~/.local/bin/github-activity
    echo "Installation complete. Run with:"
    echo "github-activity <args>"
    echo "Make sure ~/.local/bin is in your PATH"
fi
