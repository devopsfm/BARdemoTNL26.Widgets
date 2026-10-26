#!/usr/bin/env bash
# Copies a .nupkg and appends one byte, so the copy's digest no longer matches
# any attestation. Used in demo D4 to show gh attestation verify failing.
set -euo pipefail

src="${1:?usage: scripts/tamper.sh <package.nupkg>}"
dst="${src%.nupkg}.tampered.nupkg"

cp "$src" "$dst"
printf '\0' >> "$dst"

echo "Wrote $dst (one byte appended)"
