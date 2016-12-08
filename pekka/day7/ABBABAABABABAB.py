#!/usr/bin/env python
def isABBA( ipv7, i ):
	valid = False
	if i+3 < len(ipv7):
		valid = True
		for x in range(0, 4):
			t = ipv7[i+x]
			if t>'z' or t<'a':
				valid=False
	if valid and ipv7[i]==ipv7[i+3] and ipv7[i+1]==ipv7[i+2] and ipv7[i]!=ipv7[i+1]:
		return valid

def isABA( ipv7, i ):
	valid = False
	if i+2 < len(ipv7):
		valid = True
		for x in range(0, 3):
			t = ipv7[i+x]
			if t>'z' or t<'a':
				valid=False
	if valid and ipv7[i]==ipv7[i+2] and ipv7[i]!=ipv7[i+1]:
		return valid

def nrOfAbba():
	correct = 0
	with open("input.txt", 'r') as handle:
		for ipv7 in handle:
			bracket = []
			i = 0
			possible = False
			for c in ipv7:
				if c == '[':
					bracket.insert(-1, c)

				if len(bracket) != 0:
					if isABBA(ipv7, i):
						possible = False
						break
				else:
					if isABBA(ipv7, i):
						possible = True

				if c == ']':
					bracket.pop()

				i = i+1

			if possible:
				correct = correct +1

	print(correct)

def nrOfAba():
	correct = 0
	with open("input.txt", 'r') as handle:
		for ipv7 in handle:
			aba = []
			bab = []
			bracket = []
			i = 0
			possible = False
			for c in ipv7:
				if c == '[':
					bracket.insert(-1, c)

				if len(bracket) != 0:
					if isABA(ipv7, i):
						bab.insert(-1, ipv7[i:i+3])
				else:
					if isABA(ipv7, i):
						aba.insert(-1, ipv7[i:i+3])

				if c == ']':
					bracket.pop()

				i = i+1

			for a in bab:
				b = a[1] + a[0] + a[1]
				if b in aba:
					correct = correct +1
					break

	print(correct)

nrOfAbba()
nrOfAba()