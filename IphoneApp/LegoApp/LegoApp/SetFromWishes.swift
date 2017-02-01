//
//  SetFromWishes.swift
//  LegoApp
//
//  Created by Helena Tamburić on 28/01/2017.
//  Copyright © 2017 Helena Tamburić. All rights reserved.
//

import Foundation

import Unbox

struct SetFromWishes {
    
    let Id: Int
    let Ime: String
    let GodinaProizvodnje : Int
    let DijeloviBroj: Int
    let Opis: String?
    let NazivTema : String
    let Kolicina: Int
    let Slike : String
    let UputeUrl: String
    let NazivNadTema : String?
    
}

extension SetFromWishes: Unboxable {
    init(unboxer: Unboxer) throws {
        
        self.Id = try unboxer.unbox(keyPath:  "LSet.Id")
        print ("id u wishes \(self.Id)")
        self.Ime = try unboxer.unbox(keyPath: "LSet.Name")
        self.GodinaProizvodnje = try unboxer.unbox(keyPath: "LSet.ProductionYear")
        self.DijeloviBroj = try unboxer.unbox(keyPath: "LSet.NumberOfParts")
        self.Slike = try unboxer.unbox(keyPath: "LSet.PictureUrl")
        
        self.Opis = try unboxer.unbox(keyPath: "LSet.Opis")
        self.NazivTema = try unboxer.unbox(keyPath:"LSet.Theme.Name")
        self.Kolicina = try unboxer.unbox(key:  "Number")
        
        self.UputeUrl = try unboxer.unbox(keyPath: "LSet.InstructionsUrl")
        self.NazivNadTema = try unboxer.unbox(keyPath:"LSet.BaseTheme.Name")
    }
}
