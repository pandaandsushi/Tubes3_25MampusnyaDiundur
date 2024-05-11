# Tubes3_25MampusnyaDiundur
# Fingerprint Detection Using Pattern Matching
| Names                     | NIM      |
| ----------------------    |:--------:|
| Thea Josephine H          | 13522012 |
| Kayla Namira M            | 13522050 |
| Diana Tri Handayani       | 13522104 |

## Table of Contents 💫
* [Brief Overview](#brief-overview) 👾 
* [The Algorithm](#the-algorithm) 👾 
* [Tools](#tools-and-libraries) 🔨
* [Requirements](#requirements) 🫧
* [Setting Up](#setting-up) 🍀
* [How To Use](#how-to-use) 🪄

## Brief Overview 
The program takes as input a fingerprint image that needs to be matched with existing fingerprint images stored in a SQL database. It uses pattern matching algorithms (KMP, BM, and Regular Expression) to compare the input fingerprint image with the database records.

## The Algorithms
Knuth Morris Pratt (KMP)
KMP is a string matching algorithm that efficiently finds occurrences of a pattern within a longer text by exploiting the information gathered during previous comparisons.
- Preprocess the pattern to construct a partial match table (also known as failure function) that indicates the longest proper prefix of the pattern that is also a suffix. This helps in avoiding unnecessary backtracking during the matching process.
- Start matching from the beginning of the text and the pattern.
- Compare characters of the text and the pattern. If a mismatch occurs, use the information from the partial match table to determine how much to shift the pattern.
- Continue matching until the end of the text is reached or a complete match is found.

Boyer Moore (BM)
Boyer-Moore is another string matching algorithm that efficiently searches for occurrences of a pattern within a longer text by utilizing two key heuristics: the bad character rule and the good suffix rule
- Preprocess the pattern to construct two lookup tables: the bad character table and the good suffix table. These tables provide information about character mismatches and potential shifts during the matching process.
- Begin matching from the end of the pattern and the end of the current window in the text.
- Compare characters of the pattern and the text from right to left. If a mismatch occurs:
Use the bad character rule to shift the pattern to align the mismatched character with the corresponding character in the text.
If the mismatched character does not occur in the pattern, use the good suffix rule to determine the maximum shift based on the matched suffix.
- Continue matching until the end of the text is reached or a complete match is found.
## Tools and Libraries
- Visual Studio
- WinForm

## Requirements


## Setting Up
- Clone this repository on your terminal `https://github.com/pandaandsushi/Tubes3_25MampusnyaDiundur`
- Go to the `frontend` directory by using `cd src/frontend`
- Type in `npm install` to start the server on your local browser
- If error occurs after npm install, type in `npm install react-d3-graph@2.6.0 --legacy-peer-deps`.
- Type in `npm start` to start the server on your local browser
- Open a new terminal, and go to backend dir using `cd src/backend`
- Type in `go run main.go` to start the server, if your firewall blocks it, select `allow`.
- You are done :>

## How to Use
- Input the start node and end node with words as the Wikipedia title page
- Choose between using BFS or IDS algorithm
- Please be patient and the result will be displayed below as a graph

## File structure
```
.
├── README.md
├── doc
│   └── 25MampusnyaDiundur.pdf
├── src
│   ├── frontend
│   │   ├── .gitignore
│   │   ├── package.json
│   │   ├── package-lock.json
│   │   ├── README
│   │   └── public
│   │       └── src
│   │           ├── App.js
│   │           ├── App.css
│   │           ├── index.js
│   │           ├── index.css
│   │           ├── package-lock.json
│   │           ├── package.json
│   │           ├── About
│   │           │   ├── About.js
│   │           │   └── About.css
│   │           ├── Content
│   │           │   ├── Content.js
│   │           │   └── Content.css
│   │           ├── Footer
│   │           │   ├── footer.js
│   │           │   └── footer.css
│   │           ├── GraphComponent
│   │           │   ├── GraphComponent.js
│   │           │   └── GraphComponent.css
│   │           ├── Header
│   │           │   ├── Header.js
│   │           │   └── Header.css
│   │           └── How To Use
│   │               ├── HTU.js
│   │               └── HTU.css
│   ├── backend
│   │   ├── go.mod
│   │   ├── go.sum
│   │   ├── Dockerfile
│   │   ├── main.go
│   │   ├── BFS
│   │   │   ├── BFS.go
│   │   │   └── BFSfunction.go
│   │   ├── IDS
│   │   │   └── ids.go
│   │   └── Scrape
│   │       └── scraper.go
```
## Thankyou for trying our program :>
