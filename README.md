# MIT 2021 Bitcoin Hackathon
## Onion '78 - A Payjoin Implementation Over TOR

# Resources
TBD: Links, PDFs, video   
Presentation -   
Axure  -   
Video Demo -   

## Team '78
@DanGould  
@armins88  
@johnsBeharry  
@ronaldstoner   

## Problem
Mobile bitcoin wallet applications are *NOT* private enough for both the *sender* as well as the *receiver*. 

## Solution 
Our project aims to implement the payjoin standard (BIP-78) and privacy features (TOR Hidden Services) into an existing mobile wallet application (Chaincase). The ease of accessability and portability of a mobile based platform is a benefit to those who are attempting to remain as private as possible. 

## Problems Faced
1. Coordination - Transactions that require additional privacy tended to require lots of cooridnation between the transaction participants. 

2. Communication - Transmitting this information in a private and secure manner has traditionally been a challenge for bitcoin transactions.  

3. Confidentiality - Out of band communications and broadcasting of data can be noisy and raise flags when once is trying to transact privately. 

4. Hackathon [META] - How can we work remotely as a team on the same project and meet our deliverabiles within 24 hours?

## Solution(s)
1. Onion '78
    - Sender and Receiver functionality 
2. TOR Hidden Services
    - Removes the need for OOB channels
3. Payjoin
    - Many spends to one transaction
    - Extra data means more privacy
4. Project Management! 
    - Lots of calls
    - Status checks
    - Delegation of Responsibilities
    - Knowing when to call it 

## Technical Requirements / Milestones
1. [DONE] - Send and receive transactions according to the payjoin standard (BIP78)
2. [DONE] - Open a ephemeral tor hidden service for every new PSBT negotiation phase
3. [STRETCH][NOT DONE] - Alongside Tor also offer NFC as a form of offline communication between two parties

## Mobile Wallet - Chainchase
A non-custodial iOS bitcoin wallet supporting [Chaumian CoinJoin](https://github.com/nopara73/ZeroLink/#ii-chaumian-coinjoin).

## Building for iOS

make sure to have the Wasabi submodule installed:
```console
git submodule update --init --recursive
```

pull the Tor binary:
```console
git lfs pull
```
Install a provisioning profile to make use of the entitlements:
https://docs.microsoft.com/en-us/xamarin/ios/get-started/installation/device-provisioning/
